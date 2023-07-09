using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkParser
{
    //*****Constant Variables*****

    //will be deprecated
    private const string CHARACTER_TAG = "Character";
    private const string SPRITE_TAG = "Sprite";
    private const string POSITION_TAG = "Pos";



    //*****public variables & properties*****
    public string LeftCharacter; // chara names
    public string CenterCharacter;
    public string RightCharacter;

    public int LeftExp { get => leftExp; private set => leftExp = 0; }
    public int CenterExp { get => centerExp; private set => centerExp = 0; }
    public int RightExp { get => rightExp; private set => rightExp = 0; }

    public string ExpressionValue; // string of expression value, e.g. "1", "5"
    public string DisplayName;

    // this was a terrible idea in hindsight AHAHA
    public int CurrentExpToInt { get => currentExpToInt; set => currentExpToInt = 0; }

    public List<string> CurrentActiveCharactersGetOnly { get { return currentActiveCharacters; } } // directions, not chara names
    public List<string> CurrentOnScreenCharactersGetOnly { get { return currentOnScreenCharacters; } } // directions, not chara names
    public List<string> UpdatedTagsGetOnly { get { return updatedTags; } }


    // will be deprecated
    public string CurrentCharValue;
    public string CurrentSpriteValue;
    public string CurrentPositionValue;
    public int CurrentSpriteValueToInt { get => currentSpriteValueToInt; set => currentSpriteValueToInt = 0; }



    //*****private variables*****
    private int currentExpToInt;
    private List<string> currentActiveCharacters;
    private List<string> currentOnScreenCharacters;
    private List<string> updatedTags;

    private int leftExp;
    private int centerExp;
    private int rightExp;

    //will be deprecated
    private int currentSpriteValueToInt;



    //*****constructor*****
    public InkParser()
    {
        currentActiveCharacters = new List<string>();
        currentOnScreenCharacters = new List<string>();
        updatedTags = new List<string>();
    }



    //*****Public Methods*****

    // HandleTags
    // Pass in tags, split and handle them accordingly whenever a ":" is encountered in the tag.
    // store updated values in public variables, and store which tags were updated in updatedTags.
    public void HandleTags(List<string> currentTags)
    {
        updatedTags.Clear();
        bool isThereNewActive = false;
        bool isThereNewCharacter = false;

        foreach (string tag in currentTags)
        {
            //for debugging
            Debug.Log(tag);

            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case GameConstants.ACTIVE_CHARACTER:
                    if (!isThereNewActive)
                    {
                        isThereNewActive = true;
                        currentActiveCharacters.Clear();
                    }
                    currentActiveCharacters.Add(tagValue);
                    break;

                case GameConstants.DISPLAY_NAME:
                    DisplayName = tagValue;
                    break;

                case GameConstants.EXPRESSION_TAG:
                    ExpressionValue = tagValue;
                    currentExpToInt = int.Parse(ExpressionValue);
                    break;

                case GameConstants.LEFT_CHARA_TAG:
                    if (!isThereNewCharacter)
                    {
                        isThereNewCharacter = true;
                        currentOnScreenCharacters.Clear();
                    }
                    LeftCharacter = tagValue;
                    currentOnScreenCharacters.Add(tagKey);
                    break;

                case GameConstants.CENTER_CHARA_TAG:
                    if (!isThereNewCharacter)
                    {
                        isThereNewCharacter = true;
                        currentOnScreenCharacters.Clear();
                    }
                    CenterCharacter = tagValue;
                    currentOnScreenCharacters.Add(tagKey);
                    break;

                case GameConstants.RIGHT_CHARA_TAG:
                    if (!isThereNewCharacter)
                    {
                        isThereNewCharacter = true;
                        currentOnScreenCharacters.Clear();
                    }
                    RightCharacter = tagValue;
                    currentOnScreenCharacters.Add(tagKey);
                    break;

                case GameConstants.LEFT_EXP_TAG:
                    leftExp = int.Parse(tagValue);
                    break;

                case GameConstants.CENTER_EXP_TAG:
                    centerExp = int.Parse(tagValue);
                    break;

                case GameConstants.RIGHT_EXP_TAG:
                    rightExp = int.Parse(tagValue);
                    break;


                //following will be deprecated
                case CHARACTER_TAG:
                    //Debug.Log("Char Tag: " + tagKey + " " + tagValue);
                    CurrentCharValue = tagValue;
                    break;
                case SPRITE_TAG:
                    CurrentSpriteValue = tagValue;
                    currentSpriteValueToInt = int.Parse(CurrentSpriteValue);
                    //Debug.Log("Sprite Tag: " + tagKey + " " + currentSpriteValueToInt);
                    break;
                case POSITION_TAG:
                    //Debug.Log("Pos Tag: " + tagKey + " " + tagValue);
                    CurrentPositionValue = tagValue;
                    break;
                default:
                    Debug.LogError("Unidentified tagKey, unhandled: " + tagKey + " " + tagValue);
                    break;
            }

            updatedTags.Add(tagKey);
        }

        // For debugging
        //printInDebugWhatUpdated(updatedTags);
        //printInDebugWhatUpdated(currentOnScreenCharacters);
    }

    // Return a new Story object, passing in the JSON string from parameter TextAsset textJson.
    public Story MakeStoryFromTextJSON(TextAsset textJson)
    {
        Story story = new Story(textJson.text);
        return story;
    }



    //*****Private Methods*****


    //Helper. Is this the first time we detect a new actives to be added? Then, clear the previous actives before adding new actives.
    private void isNewActiveAdded(bool isThere)
    {
        if (!isThere)
        {
            isThere = true;
            currentActiveCharacters.Clear();
        }

    }

    //Helper. Is this the first time we detect new characters on the screen? Then, clear the previous characters before adding new characters.
    private void isNewCharacterAdded(bool isThere)
    {
        if (!isThere)
        {
            isThere = true;
            currentOnScreenCharacters.Clear();
        }

    }


    // For debugging. In the console, print everything that updated in one of the string lists storing things.
    private void printInDebugWhatUpdated(List<string> whatUpdated)
    {
        foreach (string t in whatUpdated)
        {
            Debug.Log("Updated " + t);
        }
    }

}
