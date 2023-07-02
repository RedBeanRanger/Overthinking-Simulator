using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkParser
{
    //*****Constant Variables*****
    private const string CHARACTER_TAG = "Character";
    private const string SPRITE_TAG = "Sprite";
    private const string POSITION_TAG = "Pos";



    //*****public Variables*****
    public string CurrentCharValue;
    public string CurrentSpriteValue;
    public string CurrentPositionValue;

    public int CurrentSpriteValueToInt { get => currentSpriteValueToInt; set => currentSpriteValueToInt = 0; }

    //*****private variables*****
    private int currentSpriteValueToInt;


    //*****Public Functions*****
    public void HandleTags(List<string> currentTags)
    {
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
                case CHARACTER_TAG:
                    Debug.Log("Char Tag: " + tagKey + " " + tagValue);
                    CurrentCharValue = tagValue;
                    break;
                case SPRITE_TAG:
                    CurrentSpriteValue = tagValue;
                    currentSpriteValueToInt = int.Parse(CurrentSpriteValue);
                    Debug.Log("Sprite Tag: " + tagKey + " " + currentSpriteValueToInt);
                    break;
                case POSITION_TAG:
                    Debug.Log("Pos Tag: " + tagKey + " " + tagValue);
                    CurrentPositionValue = tagValue;
                    break;
                default:
                    Debug.LogWarning("Unidentified tagKey, unhandled: " + tagKey + " " + tagValue);
                    break;
            }
        }
    }

}
