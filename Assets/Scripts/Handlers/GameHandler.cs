using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    // ***** Public Variables *****
    // GameObjects
    public GameObject DialogueHandlerObject;
    public GameObject SpriteHandlerObject;
    public GameObject StoryHandlerObject;

    // Handler Singleton Instances
    public static GameObject GameHandlerInstance = null;
    public static GameObject DialogueHandlerInstance = null;
    public static GameObject SpriteHandlerInstance = null;
    public static GameObject StoryHandlerInstance = null;

    // Managers
    public static ConfigManager ConfigManager = null;

    //Scriptable Object Controllers
    public BarController barControllerSO;
    public SceneController sceneControllerSO;

    // for testing purposes
    public Slider SBar;
    public Slider HBar;
    public Slider PBar;
    public Slider ABar;
    public GameObject Background;


    // ***** Private Variables *****
    //Script Handling - Handler Scripts that persist throughout the game should never be referenced outside of GameHandler, to avoid introducing dependecies
    private DialogueHandler dialogueHandlerScript = null;
    private SpriteHandler spriteHandlerScript = null;
    private StoryHandler storyHandlerScript = null;


    private Story currentStory;

    //objects
    private InkParser inkParser;

    private bool isInitSuccessful = false;
    private bool isGamePaused = false;



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

        //currentStory = inkParser.MakeStoryFromTextJSON(storyHandlerScript.CurrentTextJSON);
        currentStory = inkParser.MakeStoryFromTextJSON(sceneControllerSO.CurrentGameSceneData.InkTextJSON);
        barControllerSO.BarValueChangeEvent.AddListener(ChangeSliderValue);


        //bind story function to the barController function.
        // nvm, binding occurs in loadGame();
        //currentStory.BindExternalFunction("ChangeBarValue", (string barName, int amount) => { barControllerSO.ChangeBarValue(barName, amount); });

        dialogueHandlerScript.CurrentInkStory = currentStory;


        //On Call Start
        dialogueHandlerScript.OnCallStart();
        spriteHandlerScript.OnCallStart();

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
            loadGame();
        }

    }

    void OnDisable()
    {
        barControllerSO.BarValueChangeEvent.RemoveListener(ChangeSliderValue);
    }

    void Update()
    {
        // Game is Active
        if (!isGamePaused && !dialogueHandlerScript.AreThereChoicesGetOnly)
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

                    foreach (string s in inkParser.CurrentOnScreenCharactersGetOnly)
                    {
                        Debug.Log("InkParser is holding " + s + " on screen.");
                    }

                }

                //For testing purposes
                //The following block of code loops the game back when it's done.
                if (!dialogueHandlerScript.IsShowingDialogue && !dialogueHandlerScript.IsTyping)
                {
                    //this doesn't do anything if there are no more game scene data left.
                    sceneControllerSO.UpdateGameSceneData();
                    //reload the story
                    loadGame();
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
        switch (barName)
        {
            case "SBar":
                SBar.value = (float)newBarValue;
                Debug.Log("SBar Value Changed.");
                break;
            case "HBar":
                HBar.value = (float)newBarValue;
                Debug.Log("HBar Value Changed.");
                break;
            case "PBar":
                PBar.value = (float)newBarValue;
                Debug.Log("PBar Value Changed.");
                break;
            case "ABar":
                ABar.value = (float)newBarValue;
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
        initSingletonHandler("Story", StoryHandlerObject);

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
                    Debug.Log("Dialogue Handler initialised");
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
                    Debug.Log("Sprite Handler initialised");
                }
                break;

            case "Story":
                if (StoryHandlerInstance == null)
                {
                    StoryHandlerInstance = handlerObject;
                }
                else
                {
                    Destroy(handlerObject);
                }

                storyHandlerScript = handlerObject.GetComponent<StoryHandler>();
                if (storyHandlerScript != null)
                {
                    isInitSuccessful = true;
                    Debug.Log("Story Handler initialised");
                }
                break;

            default:
                Debug.LogError("Initialisation of Handler GameObject was unsuccessful: " + handlerObject);
                break;

        }

        // Was the initialisation successful?
        if (isInitSuccessful){
            DontDestroyOnLoad(handlerObject);
            //Debug.Log("Don't Destroy On Load ran");
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

    //temporary helper
    private void loadGame()
    {
        //currentStory = inkParser.MakeStoryFromTextJSON(storyHandlerScript.CurrentTextJSON);
        // set story and background
        //using SceneController
        currentStory = inkParser.MakeStoryFromTextJSON(sceneControllerSO.CurrentGameSceneData.InkTextJSON);
        Background.GetComponent<SpriteRenderer>().sprite = sceneControllerSO.CurrentGameSceneData.BackgroundSprite;


        dialogueHandlerScript.CurrentInkStory = currentStory;
        //currentStory.BindExternalFunction("ChangeBarValue", (string barName, int amount) => { Debug.Log("Yoohoohoo it's bound! " + barName + " " + amount); });
        currentStory.BindExternalFunction("ChangeBarValue", (string barName, int amount) => { barControllerSO.ChangeBarValue(barName, amount); });

        dialogueHandlerScript.ShowDialogue();

        inkParser.HandleTags(currentStory.currentTags);
        dialogueHandlerScript.DisplayName = inkParser.DisplayName;
        dialogueHandlerScript.ShowName();

        //sprite handler updates
        spriteHandlerScript.SetSpriteObjectsActive(inkParser.CurrentOnScreenCharactersGetOnly);
        spriteHandlerScript.SetCharacterColors(inkParser.CurrentActiveCharactersGetOnly);
        loadAllSprites();

    }

    private void loadAllSprites()
    {
        spriteHandlerScript.SetLeftSpriteExp(inkParser.LeftCharacter, inkParser.LeftExp);
        spriteHandlerScript.SetCenterSpriteExp(inkParser.CenterCharacter, inkParser.CenterExp);
        spriteHandlerScript.SetRightSpriteExp(inkParser.RightCharacter, inkParser.RightExp);
    }


    //***** Deprecated methods *****
}
