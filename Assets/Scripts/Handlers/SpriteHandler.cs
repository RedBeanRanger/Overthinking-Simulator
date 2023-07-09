using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
    //*****public variables & properties*****
    public GameObject LeftSprite;
    public GameObject CenterSprite;
    public GameObject RightSprite;

    public Sprite[] NPCSprites;
    public Sprite[] AnxiousSprites;


    //*****private variables*****
    [SerializeField]
    private SpriteRenderer leftSpriteRenderer;
    [SerializeField]
    private SpriteRenderer centerSpriteRenderer;
    [SerializeField]
    private SpriteRenderer rightSpriteRenderer;

    private bool leftIsOn = false;
    private bool centerIsOn = false;
    private bool rightIsOn = false;

    private bool leftActive = false;
    private bool centerActive = false;
    private bool rightActive = false;

    private Sprite[] currentSpritesRef; // reference to the current sprite array we want to use



    //*****Public Methods*****
    public void OnCallStart()
    {
        leftSpriteRenderer = LeftSprite.GetComponent<SpriteRenderer>();
        centerSpriteRenderer = CenterSprite.GetComponent<SpriteRenderer>();
        rightSpriteRenderer = RightSprite.GetComponent<SpriteRenderer>();

        //if no renderer was found for one of these, stop the game
        if (leftSpriteRenderer == null || centerSpriteRenderer == null || rightSpriteRenderer == null)
        {
            Debug.LogError("Could not get a sprite renderer component.");
        }

        LeftSprite.SetActive(false);
        CenterSprite.SetActive(false);
        RightSprite.SetActive(false);
    }


    public void SetSpriteObjectsActive(List<string> currentOnScreenCharacters)
    {
        resetCharacterBools();

        foreach (string s in currentOnScreenCharacters)
        {
            // set gameobjects containing the sprites active
            switch (s)
            {
                case GameConstants.LEFT_CHARA_TAG:
                    LeftSprite.SetActive(true);
                    leftIsOn = true;
                    break;
                case GameConstants.CENTER_CHARA_TAG:
                    CenterSprite.SetActive(true);
                    centerIsOn = true;
                    break;
                case GameConstants.RIGHT_CHARA_TAG:
                    RightSprite.SetActive(true);
                    rightIsOn = true;
                    break;
            }

            // set nonactive gameobjects inactive
            if (!leftIsOn)
            {
                LeftSprite.SetActive(false);
                leftIsOn = false; // unneeded but just to make 100% sure
            }

            if (!centerIsOn)
            {
                CenterSprite.SetActive(false);
                centerIsOn = false; // unneeded but just to make 100% sure
            }
            if (!rightIsOn)
            {
                RightSprite.SetActive(false);
                rightIsOn = false; // unneeded but just to make 100% sure
            }

        }
    }

    public void SetSprites(string leftCharacter, string centerCharacter, string rightCharacter)
    {
        if (leftIsOn && leftCharacter != null)
        {
            setCorrespondingCharacter(leftSpriteRenderer, leftCharacter);
        }
        if (centerIsOn && centerCharacter != null)
        {
            setCorrespondingCharacter(centerSpriteRenderer, centerCharacter);
        }

        if (rightIsOn && rightCharacter != null)
        {
            setCorrespondingCharacter(rightSpriteRenderer, rightCharacter);
        }
    }

    public void SetLeftSpriteExp(string leftCharacter, int leftExp)
    {
        if (leftIsOn && leftCharacter != null)
        {
            setCorrespondingCharacter(leftSpriteRenderer, leftCharacter, leftExp);
        }
    }

    public void SetCenterSpriteExp(string centerCharacter, int centerExp)
    {
        if (centerIsOn && centerCharacter != null)
        {
            setCorrespondingCharacter(centerSpriteRenderer, centerCharacter, centerExp);
        }
    }

    public void SetRightSpriteExp(string rightCharacter, int rightExp)
    {
        if (rightIsOn && rightCharacter != null)
        {
            setCorrespondingCharacter(rightSpriteRenderer, rightCharacter, rightExp);
        }
    }


    // Assume colors will always be set after objects are set active.
    // Check who's active in the scene. All active characters will be set to normal color. Other characters are set to Idle.
    public void SetCharacterColors(List<string> currentActiveCharacters)
    {
        resetActiveBools();
        // set the active characters a normal color.
        foreach (string s in currentActiveCharacters)
        {
            switch (s)
            {
                case GameConstants.LEFT_CHARA_TAG:
                    if (leftIsOn)
                    {
                        leftSpriteRenderer.color = GameConstants.NORMAL_COLOR;
                        leftActive = true;
                    }
                    break;
                case GameConstants.CENTER_CHARA_TAG:
                    if (centerIsOn)
                    {
                        centerSpriteRenderer.color = GameConstants.NORMAL_COLOR;
                        centerActive = true;
                    }
                    break;
                case GameConstants.RIGHT_CHARA_TAG:
                    if (rightIsOn)
                    {
                        rightSpriteRenderer.color = GameConstants.NORMAL_COLOR;
                        rightActive = true;
                    }
                    break;
            }

            // set the sprites that are on but not active as idle color
            if (leftIsOn && !leftActive)
            {
                leftSpriteRenderer.color = GameConstants.IDLE_COLOR;
            }

            if (centerIsOn && !centerActive)
            {
                centerSpriteRenderer.color = GameConstants.IDLE_COLOR;
            }

            if (rightIsOn && !rightActive)
            {
                rightSpriteRenderer.color = GameConstants.IDLE_COLOR;
            }
        }
    }



    //*****Private Methods*****
    private void setCorrespondingCharacter(SpriteRenderer sR, string charName)
    {
        setCurrentSpritesRef(charName);
        sR.sprite = currentSpritesRef[0]; //temp code, just set the spriterenderer's sprite component to ind 0 of whatever sprites
    }

    private void setCorrespondingCharacter(SpriteRenderer sR, string charName, int expInd)
    {
        setCurrentSpritesRef(charName);
        if (!(expInd >= 0 && expInd < currentSpritesRef.Length)) //if the exp was out of bounds, set it to default 0 before proceeding
        {
            expInd = 0;
            //Debug.LogWarning("Exp was out of bounds");
        }
        sR.sprite = currentSpritesRef[expInd];
    }

    // set the current sprites we want to be referencing in currentSpritesRef based on given charName
    private void setCurrentSpritesRef(string charName)
    {
        switch (charName)
        {
            //MCs
            case GameConstants.ANXIOUS_MC:
                currentSpritesRef = AnxiousSprites;
                break;

            //NPCs
            case GameConstants.BLOB_NPC:
                currentSpritesRef = NPCSprites;
                break;
        }
    }

    private void resetCharacterBools()
    {
        leftIsOn = false;
        centerIsOn = false;
        rightIsOn = false;
    }

    private void resetActiveBools()
    {
        leftActive = false;
        centerActive = false;
        rightActive = false;
    }

}
