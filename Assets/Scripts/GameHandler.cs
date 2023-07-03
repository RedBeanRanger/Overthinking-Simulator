using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // ***** Public Variables *****
    // GameObjects
    public GameObject DialogueHandlerObject;

    // Handler Singleton Instances
    public static GameObject GameHandlerInstance = null;
    public static GameObject DialogueHandlerInstance = null;

    // Managers
    public static ConfigManager ConfigManager = null;


    // ***** Private Variables *****
    //Script Handling - Scripts that persist throughout the game should never be referenced outside of GameHandler, to avoid introducing dependecies
    private DialogueHandler dialogueHandlerScript = null;

    private bool isInitSuccessful = false;
    private bool isGamePaused = false;



    //*****Monobehaviour Functions*****
    // ONLY THIS CLASS should directly use Awake, Start and Update(s), to avoid introducing dependecies and to ensure the order of code execution, 

    void Awake()
    {
        Debug.Log("Game Handler is Awake");
        init();
    }

    void Start()
    {
        dialogueHandlerScript.OnStart();
        if (!dialogueHandlerScript.IsShowingDialogue && !dialogueHandlerScript.IsTyping)
        {
            dialogueHandlerScript.ShowDialogue();
        }
    }

    void Update()
    {
        // Game is Active
        if (!isGamePaused && !dialogueHandlerScript.GetOnlyAreThereChoices)
        {
            if (Input.GetKeyDown(ConfigManager.ActionInputs["Action Confirm"]))
            {
                if (dialogueHandlerScript.IsShowingDialogue)
                {
                    dialogueHandlerScript.ContinueDialogue();
                }

                //For testing purposes
                //The following block of code loops the game back when it's done.
                if (!dialogueHandlerScript.IsShowingDialogue && !dialogueHandlerScript.IsTyping)
                {
                    dialogueHandlerScript.ShowDialogue();
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



    // *****Private Methods*****
    // init - Initialise singleton instances for handlers and managers, including this one.
    private void init()
    {
        // Initialise Handlers (new singleton instances)
        initGame();
        initSingletonHandler("Dialogue", DialogueHandlerObject);

        // Create new Manager object
        ConfigManager = new ConfigManager();

    }

    // initGame - Initialise game as singleton
    private void initGame()
    {
        if (GameHandlerInstance == null)
        {
            GameHandlerInstance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }

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
                isInitSuccessful = true;
                Debug.Log("Dialogue Handler initialised");
                break;

            default:
                Debug.LogError("Initialisation of Handler GameObject was unsuccessful: " + handlerObject);
                break;
        }
        if (isInitSuccessful){
            DontDestroyOnLoad(handlerObject);
            isInitSuccessful = false;
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


    //***** Deprecated methods *****
    // this is taken care of by initSingletonHandler now.
    private void initDialogueHandler()
    {
        // Confirm the current Dialogue Handler Object is the only existing instance of a Dialogue Handler Object.
        // If a Dialogue Handler Object already exists, destroy the other Dialogue Handler Object. (IT'S AN IMPOSTER DO NOT TRUST IT!)
        if (DialogueHandlerInstance == null)
        {
            DialogueHandlerInstance = DialogueHandlerObject;
        }
        else
        {
            Destroy(DialogueHandlerObject);
        }

        // Assign corresponding gameobjects
        DialogueHandlerObject = GameObject.Find("DialogueHandler");

        // Obtain handler scripts
        dialogueHandlerScript = DialogueHandlerObject.GetComponent<DialogueHandler>();

        // Don't destroy on load
        DontDestroyOnLoad(DialogueHandlerObject);
    }
}
