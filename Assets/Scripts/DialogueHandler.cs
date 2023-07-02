using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueHandler : MonoBehaviour
{
    // ***** Public Fields *****
    public GameObject ChoiceCanvas;
    public GameObject DialogueCanvas;
    public TextAsset TestInkJson;

    public float TypeDelay = 2.5f; //How much time to wait

    //properties
    public bool IsShowingDialogue { get => isShowingDialogue; set => isShowingDialogue = false; }
    public bool IsTyping { get => isTyping; set => isTyping = false; }
    public bool IsDialogueEndReached { get => isDialogueEndReached; set => isDialogueEndReached = false; }
    public bool TriggerStopTyping { get => triggerStopTyping; set => triggerStopTyping = false; }



    // ***** Private Fields *****
    // All these serialize field stuff is temporary code
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private SpriteRenderer characterRenderer;
    [SerializeField]
    private Sprite[] characterSprites;
    [SerializeField]
    private GameObject[] choiceButtons;
    [SerializeField]
    private List<TextMeshProUGUI> choicesTexts;

    private GameObject endIndicator;

    
    private InkParser inkParser;
    private Story currentInkStory;

    //linked to properties
    private bool isShowingDialogue;
    private bool isTyping;
    private bool isDialogueEndReached;
    private bool triggerStopTyping;

    // ***** Public Methods *****

    public void OnStart()
    {
        endIndicator = GameObject.Find("EndIndicator");
        inkParser = new InkParser();
        choicesTexts = new List<TextMeshProUGUI>();
        foreach (GameObject choice in choiceButtons)
        {
            choice.SetActive(false);
            //Debug.Log(choice.activeSelf);
            choicesTexts.Add(choice.transform.GetChild(0).GetComponent<TextMeshProUGUI>());
            if (choice.transform.GetChild(0).GetComponent<TextMeshProUGUI>() == null)
            {
                Debug.LogWarning("One of the children is empty.");
            }
        }
    }

    public void ShowDialogue()
    {
        isShowingDialogue = true;

        //test dialogue
        currentInkStory = new Story(TestInkJson.text);
        StartCoroutine(TypeDialogue(currentInkStory.Continue())); //start the typing Coroutine.
        updateTags(); //updates name, portrait

    }

    public IEnumerator TypeDialogue(string line)
    {
        isTyping = true;
        disableEndIndicator();
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            if (triggerStopTyping)
            {
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(Time.fixedDeltaTime * Time.timeScale * TypeDelay);
        }
        if (triggerStopTyping)
        {
            dialogueText.text = line;
        }
        isTyping = false;
        enableEndIndicator();
        triggerStopTyping = false;
        displayChoices();// Display the choices at the end of the coroutine
    }

    public void ContinueDialogue()
    {
        if (isTyping)
        {
            triggerStopTyping = true;
        }

        if (triggerStopTyping)
        {
            return;
        }

        if (currentInkStory.canContinue)
        {
            StartCoroutine(TypeDialogue(currentInkStory.Continue()));
            updateTags(); // updates name, portrait here
        }
        else
        {
            stopDialogue();
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentInkStory.ChooseChoiceIndex(choiceIndex);
        Debug.Log(choiceIndex);
        disableAllChoices();
        ContinueDialogue();
    }

    // ***** Private Methods *****

    private void displayChoices()
    {
        //currentChoices() is a builtin function for Ink Stories.
        //Choice is also an object from Ink.Runtime.
        List<Choice> currentChoices = currentInkStory.currentChoices;

        //defensive check
        if (currentChoices.Count > choiceButtons.Length)
        {
            Debug.LogError("Number of choices greater than number of buttons");
        }

        //assign each choice to a button.
        int ind = 0;
        foreach (Choice c in currentChoices)
        {
            choiceButtons[ind].SetActive(true);
            choicesTexts[ind].text = c.text;
            ind += 1;
        }


        for (int i = ind; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].SetActive(false);
        }
    }

    private void disableAllChoices()
    {
        for (int ind = 0; ind < choiceButtons.Length; ind++)
        {
            choiceButtons[ind].SetActive(false);
        }
    }

    private void stopDialogue()
    {
        isShowingDialogue = false;
        isDialogueEndReached = true;
    }

    private void enableEndIndicator()
    {
        endIndicator.SetActive(true);
    }

    private void disableEndIndicator()
    {
        endIndicator.SetActive(false);
    }

    private void updateTags()
    {
        inkParser.HandleTags(currentInkStory.currentTags);
        nameText.text = inkParser.CurrentCharValue;
        characterRenderer.sprite = characterSprites[inkParser.CurrentSpriteValueToInt];
    }

}
