using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkParser
{
    //*****Constant Variables*****
    private const string ACTIVE_CHARACTER = "Active"; //specify Left, Center, Right, or None
    private const string LEFT_CHARA_TAG = "Left"; //specify characterName
    private const string CENTER_CHARA_TAG = "Center";
    private const string RIGHT_CHARA_TAG = "Right";
    private const string EXPRESSION_TAG = "Exp"; //specify sprite index number for the expression

    //will be deprecated
    private const string CHARACTER_TAG = "Character";
    private const string SPRITE_TAG = "Sprite";
    private const string POSITION_TAG = "Pos";



    //*****public variables & properties*****
    public string LeftCharacter;
    public string CenterCharacter;
    public string RightCharacter;
    public string ExpressionValue;

    public int CurrentExpToInt { get => currentExpToInt; set => currentExpToInt = 0; }

    public List<string> CurrentActiveCharactersGetOnly { get { return currentActiveCharacters; } }
    public List<string> UpdatedTagsGetOnly { get { return updatedTags; } }


    // will be deprecated
    public string CurrentCharValue;
    public string CurrentSpriteValue;
    public string CurrentPositionValue;
    public int CurrentSpriteValueToInt { get => currentSpriteValueToInt; set => currentSpriteValueToInt = 0; }



    //*****private variables*****
    private int currentExpToInt;
    private List<string> currentActiveCharacters;
    private List<string> updatedTags;

    //will be deprecated
    private int currentSpriteValueToInt;



    //*****constructor*****
    public InkParser()
    {
        currentActiveCharacters = new List<string>();
        updatedTags = new List<string>();
    }



    //*****Public Functions*****

    // HandleTags
    // Pass in tags, split and handle them accordingly whenever a ":" is encountered in the tag.
    // store which tags were updated in updatedTags.
    public void HandleTags(List<string> currentTags)
    {
        updatedTags.Clear();
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case ACTIVE_CHARACTER:
                    currentActiveCharacters.Add(tagValue);
                    break;
                case LEFT_CHARA_TAG:
                    LeftCharacter = tagValue;
                    break;
                case CENTER_CHARA_TAG:
                    CenterCharacter = tagValue;
                    break;
                case RIGHT_CHARA_TAG:
                    RightCharacter = tagValue;
                    break;
                case EXPRESSION_TAG:
                    ExpressionValue = tagValue;
                    currentExpToInt = int.Parse(ExpressionValue);
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

        //Debug.Log("Updated Tags: " + updatedTags.ToString());
    }

    // Return a new Story object, passing in the JSON string from parameter TextAsset textJson.
    public Story MakeStoryFromTextJSON(TextAsset textJson)
    {
        Story story = new Story(textJson.text);
        return story;
    }


}
