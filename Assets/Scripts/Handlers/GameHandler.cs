using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameHandler : MonoBehaviour
{
    // ***** Public Variables *****
    // GameObjects
    public GameObject DialogueHandlerObject;
    public GameObject SpriteHandlerObject;

    // Handler Singleton Instances
    public static GameObject GameHandlerInstance = null;
    public static GameObject DialogueHandlerInstance = null;
    public static GameObject SpriteHandlerInstance = null;

    // Managers
    public static ConfigManager ConfigManager = null;

    // UnityEvents
    public UnityEvent LoadGameEvent;

    // Game UI
    // for testing purposes
    public Slider SBar;
    public Slider HBar;
    public Slider PBar;
    public Slider ABar;
    public GameObject Background;

    // Transition Tweening
    public EasingTweenTestScript transitionTweener;

    // ***** Private Variables *****
    //Script Handling - Handler Scripts that persist throughout the game should never be referenced outside of GameHandler, to avoid introducing dependecies
    private DialogueHandler dialogueHandlerScript = null;
    private SpriteHandler spriteHandlerScript = null;

    //Scriptable Object Controllers
    [SerializeField]
    private BarController barControllerSO;
    [SerializeField]
    private GameSceneController gameSceneControllerSO;
    [SerializeField]
    private VariableController varaibleControllerSO;

    private Story currentStory;

    //objects
    private InkParser inkParser;

    // bools
    private bool isInitSuccessful = false;
    private bool isGamePaused = false;

    // ints and floats
    // track number of times game has been loaded this session
    private int loadGameTimes = 0;

    private float coroutineTimer = 0;
    private float barLerpSpeed = .5f;



    //*****Monobehaviour Functions*****
    // ONLY THIS CLASS should directly use Awake, Start and Update(s), to avoid introducing dependecies and to ensure the order of code execution
    // OnEnable on the controllers will activate before Start.

    void Awake()
    {
        //Debug.Log("Game Handler is Awake");
        init();

    }

    void Start()
    {
        //load the current story
        currentStory = inkParser.MakeStoryFromTextJSON(gameSceneControllerSO.CurrentGameSceneData.InkTextJSON);
        dialogueHandlerScript.CurrentInkStory = currentStory;

        //disregard next part, binding occurs in loadGame(); in case some gameScenes do not make use of ExternalFunctions
        //currentStory.BindExternalFunction("ChangeBarValue", (string barName, int amount) => { barControllerSO.ChangeBarValue(barName, amount); });


        //On Call Start
        dialogueHandlerScript.OnCallStart();
        spriteHandlerScript.OnCallStart();
        transitionTweener.OnCallStart();


        //Reset the bar values
        barControllerSO.ResetBarValues();

        // Assign current character values to bars
        barControllerSO.CurrentCharacterName = "AnxiousChan";
        barControllerSO.SetStartValues("AnxiousChan");
        // display the starting values
        ChangeSliderValue("SBar", barControllerSO.SBarValue);
        ChangeSliderValue("HBar", barControllerSO.HBarValue);
        ChangeSliderValue("PBar", barControllerSO.PBarValue);
        ChangeSliderValue("ABar", barControllerSO.ABarValue);

        // Events
        // listen for a BarValueChangeEvent from barController ScriptableObject, as soon as that event fires, run ChangeSliderValue
        barControllerSO.BarValueChangeEvent.AddListener(ChangeSliderValue);


        // listen for the LoadGameEvent
        if (LoadGameEvent == null)
        {
            LoadGameEvent = new UnityEvent();
        }
        // run transition every time the game is reloaded
        LoadGameEvent.AddListener(transitionTweener.RunYDualBounce);
        //LoadGameEvent.AddListener(transitionTweener.RunRandomYTransition);


        // Prepare to show dialogue
        inkParser.HandleTags(currentStory.currentTags);

        //For Debugging
        /*
        foreach (string s in inkParser.CurrentOnScreenCharactersGetOnly)
        {
            Debug.Log("InkParser is holding " + s + " on screen.");
        }
        */

        if (!dialogueHandlerScript.IsShowingDialogue && !dialogueHandlerScript.IsTyping)
        {
            //loadGame();
            LoadGameEvent.Invoke();
            Invoke("loadGame", transitionTweener.TransitionTime);
        }

    }

    void Update()
    {
        // Check if Game is in active to take in inputs.
        if (!isGamePaused && !dialogueHandlerScript.AreThereChoicesGetOnly && !transitionTweener.IsInTransition)
        {
            if (Input.GetKeyDown(ConfigManager.ActionInputs["Action Confirm"]))
            {
                // Desired Behavior:
                // inkParser.HandleTags();
                // sprite handler updates with proper sprites
                // dialogueHandler updates with proper dialogue

                // Notes: Should the dialogue start running in Update or in Start()?

                if (dialogueHandlerScript.IsShowingDialogue)
                {
                    // dialogueHandler continues the story... but why should dialogue handler be responsible for that?
                    dialogueHandlerScript.ContinueDialogue();

                    //ink parser handles the tags
                    inkParser.HandleTags(currentStory.currentTags);

                    //sprite handler updates
                    spriteHandlerScript.SetSpriteObjectsActive(inkParser.CurrentOnScreenCharactersGetOnly);
                    spriteHandlerScript.SetCharacterColors(inkParser.CurrentActiveCharactersGetOnly);
                    //spriteHandlerScript.SetSprites(inkParser.LeftCharacter, inkParser.CenterCharacter, inkParser.RightCharacter);
                    loadAllSprites();

                    // dialogue handler updates
                    dialogueHandlerScript.DisplayName = inkParser.DisplayName;
                    dialogueHandlerScript.ShowName();

                    //debugging
                    /*
                    foreach (string s in inkParser.CurrentOnScreenCharactersGetOnly)
                    {
                        Debug.Log("InkParser is holding " + s + " on screen.");
                    }
                    */

                }

                //For testing purposes
                //The following block of code loops the game back when it's done.
                if (!dialogueHandlerScript.IsShowingDialogue && !dialogueHandlerScript.IsTyping)
                {
                    /*
                    //this doesn't do anything if there are no more game scene data left.
                    gameSceneControllerSO.UpdateGameSceneData();
                    */
                    //reload the story
                    //loadGame();
                    LoadGameEvent.Invoke();
                    Invoke("loadGame", transitionTweener.TransitionTime); // load the game after the first part of the transition is run.
                }
            }
        }


        // Pausing Behavior
        if (Input.GetKeyDown(ConfigManager.ActionInputs["Action Escape"]))
        {
            if (isGamePaused)
            {
                unpauseGame();
            }

            else
            {
                pauseGame();
            }
        }
    }

    void FixedUpdate()
    {

    }



    // *****Public Methods*****
    public void ChangeSliderValue(string barName, int newBarValue)
    {
        coroutineTimer = 0f;
        switch (barName)
        {
            case "SBar":
                StartCoroutine(LerpSBar(newBarValue));
                //oldValue = SBar.value;
                //SBar.value = Mathf.Lerp(oldValue, (float)newBarValue, Time.deltaTime * 3);
                //SBar.value = (float)newBarValue;
                //Debug.Log("SBar Value Changed.");
                break;
            case "HBar":
                StartCoroutine(LerpHBar(newBarValue));
                //HBar.value = (float)newBarValue;
                //Debug.Log("HBar Value Changed.");
                break;
            case "PBar":
                StartCoroutine(LerpPBar(newBarValue));
                //PBar.value = (float)newBarValue;
                //Debug.Log("PBar Value Changed.");
                break;
            case "ABar":
                StartCoroutine(LerpABar(newBarValue));
                //ABar.value = (float)newBarValue;
                break;

        }
    }



    // *****Private Methods*****
    // init - Initialise singleton instances for handlers and managers, including this one.
    private void init()
    {
        // Initialise Handlers (new singleton instances)
        initGame();
        DialogueHandlerObject = GameObject.Find("DialogueHandler");
        SpriteHandlerObject = GameObject.Find("SpriteHandler");
        initSingletonHandler("Dialogue", DialogueHandlerObject);
        initSingletonHandler("Sprite", SpriteHandlerObject);

        // Create new Manager object
        ConfigManager = new ConfigManager();

    }

    // initGame - Initialise game as singleton, and initialise any objects that GameHandler uses that other scripts don't.
    private void initGame()
    {
        // initialise game as singleton
        if (GameHandlerInstance == null)
        {
            GameHandlerInstance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }

        // initialise objects
        inkParser = new InkParser();

        // Don't destroy on load
        DontDestroyOnLoad(this.gameObject);
    }


    // initSingletonHandler - Initialises a singleton handler. handlerType determines the variables initialised.
    private void initSingletonHandler(string handlerType, GameObject handlerObject)
    {
        switch (handlerType)
        {
            case "Dialogue":
                if (DialogueHandlerInstance == null)
                {
                    DialogueHandlerInstance = handlerObject;
                }
                else
                {
                    Destroy(handlerObject);
                }

                dialogueHandlerScript = handlerObject.GetComponent<DialogueHandler>();

                // defensive check
                if (dialogueHandlerScript != null && DialogueHandlerInstance != null)
                {
                    isInitSuccessful = true;
                    //Debug.Log("Dialogue Handler initialised");
                }
                break;


            case "Sprite":
                if (SpriteHandlerInstance == null)
                {
                    SpriteHandlerInstance = handlerObject;
                }
                else
                {
                    Destroy(handlerObject);
                }

                spriteHandlerScript = handlerObject.GetComponent<SpriteHandler>();
                if (spriteHandlerScript != null)
                {
                    isInitSuccessful = true;
                    //Debug.Log("Sprite Handler initialised");
                }
                break;

            default:
                Debug.LogError("Initialisation of Handler GameObject was unsuccessful: " + handlerObject);
                break;

        }

        // Was the initialisation successful?
        if (isInitSuccessful){
            DontDestroyOnLoad(handlerObject);
            isInitSuccessful = false;
        }
        else
        {
            Debug.LogError("Error: Initialisation was not successful, for: " + handlerType + " Handler");
        }
    }

    private void pauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
    }

    private void unpauseGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
    }


    

    private IEnumerator LerpSBar(float newValue)
    {
        float oldValue = SBar.value;
        while (coroutineTimer < 1)
        {
            coroutineTimer += Time.deltaTime * barLerpSpeed;
            SBar.value = Mathf.Lerp(oldValue, newValue, coroutineTimer);
        }
        yield return null;
    }

    private IEnumerator LerpHBar(float newValue)
    {
        float oldValue = HBar.value;
        while (coroutineTimer < 1)
        {
            coroutineTimer += Time.deltaTime * barLerpSpeed;
            HBar.value = Mathf.Lerp(oldValue, newValue, coroutineTimer);
        }
        yield return null;

    }

    private IEnumerator LerpPBar(float newValue)
    {
        float oldValue = PBar.value;
        while (coroutineTimer < 1)
        {
            coroutineTimer += Time.deltaTime * barLerpSpeed;
            PBar.value = Mathf.Lerp(oldValue, newValue, coroutineTimer);
        }
        yield return null;
    }

    private IEnumerator LerpABar(float newValue)
    {
        float oldValue = ABar.value;
        while (coroutineTimer < 1)
        {
            coroutineTimer += Time.deltaTime * barLerpSpeed;
            ABar.value = Mathf.Lerp(oldValue, newValue, coroutineTimer);
        }
        yield return null;

    }
    

    //temporary helper
    private void loadGame()
    {
        if (loadGameTimes > 0)
        {
            // does nothing if no more game scenes can be loaded.
            gameSceneControllerSO.UpdateGameSceneData(); // if this is the first time loading the game, don't update the gameSceneData.
        }

        //currentStory = inkParser.MakeStoryFromTextJSON(storyHandlerScript.CurrentTextJSON);
        // set story and background
        //using SceneController
        currentStory = inkParser.MakeStoryFromTextJSON(gameSceneControllerSO.CurrentGameSceneData.InkTextJSON);
        Background.GetComponent<SpriteRenderer>().sprite = gameSceneControllerSO.CurrentGameSceneData.BackgroundSprite;

        dialogueHandlerScript.CurrentInkStory = currentStory;

        //bind external functions
        currentStory.BindExternalFunction("ChangeBarValue", (string barName, int amount) => { barControllerSO.ChangeBarValue(barName, amount); });
        try
        {
            currentStory.BindExternalFunction("SpriteShakeL", () => { spriteHandlerScript.SpriteShakeL(); });
            currentStory.BindExternalFunction("SpriteShakeC", () => { spriteHandlerScript.SpriteShakeC(); });
            currentStory.BindExternalFunction("SpriteShakeR", () => { spriteHandlerScript.SpriteShakeR(); });

            currentStory.BindExternalFunction("SpriteBounceL", () => { spriteHandlerScript.SpriteBounceL(); });
            currentStory.BindExternalFunction("SpriteBounceC", () => { spriteHandlerScript.SpriteBounceC(); });
            currentStory.BindExternalFunction("SpriteBounceR", () => { spriteHandlerScript.SpriteBounceR(); });

            currentStory.BindExternalFunction("SpriteMoveL", (int units, float time) => { spriteHandlerScript.SpriteMoveL(units, time); });
            currentStory.BindExternalFunction("SpriteMoveC", (int units, float time) => { spriteHandlerScript.SpriteMoveC(units, time); });
            currentStory.BindExternalFunction("SpriteMoveR", (int units, float time) => { spriteHandlerScript.SpriteMoveR(units, time); });
        }
        catch
        {
            Debug.Log("Terrible awful, something did not bind properly TuT");
        }

        dialogueHandlerScript.ShowDialogue();

        inkParser.HandleTags(currentStory.currentTags);
        dialogueHandlerScript.DisplayName = inkParser.DisplayName;
        dialogueHandlerScript.ShowName();

        //sprite handler updates
        spriteHandlerScript.SetSpriteObjectsActive(inkParser.CurrentOnScreenCharactersGetOnly);
        spriteHandlerScript.SetCharacterColors(inkParser.CurrentActiveCharactersGetOnly);
        loadAllSprites();
        loadGameTimes++;
    }

    private void loadAllSprites()
    {
        spriteHandlerScript.SetLeftSpriteExp(inkParser.LeftCharacter, inkParser.LeftExp);
        spriteHandlerScript.SetCenterSpriteExp(inkParser.CenterCharacter, inkParser.CenterExp);
        spriteHandlerScript.SetRightSpriteExp(inkParser.RightCharacter, inkParser.RightExp);
    }


    //***** Deprecated methods *****
}
