using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
    //*****public variables & properties*****
    public GameObject LeftSprite;
    public GameObject CenterSprite;
    public GameObject RightSprite;



    //*****private variables*****
    private GameConstants gameConstants;



    //*****Constructor Method*****
    public SpriteHandler()
    {
        gameConstants = new GameConstants();
    }


    //*****Public Functions*****
    public void SetCharactersActive(List<string> currentActiveCharacters)
    {
        foreach (string s in currentActiveCharacters)
        {
            switch (s)
            {
                case GameConstants.LEFT_CHARA_TAG:
                    LeftSprite.SetActive(true);
                    break;
                case GameConstants.CENTER_CHARA_TAG:
                    CenterSprite.SetActive(true);
                    break;
                case GameConstants.RIGHT_CHARA_TAG:
                    RightSprite.SetActive(true);
                    break;
            }
        }
    }
}
