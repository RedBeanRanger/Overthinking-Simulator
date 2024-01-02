using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class SpriteHandler : MonoBehaviour
{
    //*****public variables & properties*****
    public GameObject LeftSprite;
    public GameObject CenterSprite;
    public GameObject RightSprite;

    public Sprite[] AnxiousSprites;

    public Sprite[] HistoryTeacherSprites;
    public Sprite[] BlondeFriendSprites;

    public Sprite[] NPCSprites;
    public Sprite[] StudentNPCSprites;


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

    private bool leftCoroutineRunning = false;
    private bool centerCoroutineRunning = false;
    private bool rightCoroutineRunning = false;

    private Coroutine leftCoroutine;
    private Coroutine centerCoroutine;
    private Coroutine rightCoroutine;

    private Sprite[] currentSpritesRef; // reference to the current sprite array we want to use



    //*****Public Methods*****
    // rendering sprites
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

                // some finicky code
                // if there is a NONE in any of the position tags, don't render a single sprite on screen.
                case GameConstants.NONE:
                    leftIsOn = false;
                    centerIsOn = false;
                    rightIsOn = false;
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
                case GameConstants.NONE:
                    leftSpriteRenderer.color = GameConstants.IDLE_COLOR;
                    centerSpriteRenderer.color = GameConstants.IDLE_COLOR;
                    rightSpriteRenderer.color = GameConstants.IDLE_COLOR;
                    leftActive = false;
                    centerActive = false;
                    rightActive = false;
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



    // sprite actions

    public void SpriteShakeR()
    {
        /*
        // i DON'T understand why this doesn't work ahhhh
        //Vector3[] shakepath = new Vector3[] {tempmin, tempmax, tempmin, tempmax, temppos};
        //Vector3[] shakepath = new Vector3[] { tempmin, tempmax, tempmin, temppos };

        //LTSpline ltpath = new LTSpline(shakepath);
        //RightSprite.LeanMoveSplineLocal(shakepath, .5f);
        //LeanTween.moveSpline(RightSprite, ltpath, .5f);
        */

        stopRightCoroutine(); // preventative code: if another coroutine is already running, stop it and run this coroutine.
        if (!rightCoroutineRunning)
        {
            rightCoroutine = StartCoroutine(shakeSpriteFull(RightSprite, "right", .03f, .03f, .03f));
        }
    }

    public void SpriteShakeL()
    {
        stopLeftCoroutine(); // preventative code, make sure two coroutines aren't running at once.
        if (!leftCoroutineRunning)
        {
            leftCoroutine = StartCoroutine(shakeSpriteFull(LeftSprite, "left", .03f, .03f, .03f));
        }
    }

    public void SpriteShakeC()
    {
        stopCenterCoroutine();
        if (!centerCoroutineRunning)
        {
            centerCoroutine = StartCoroutine(shakeSpriteFull(CenterSprite, "center", .03f, .03f, .03f));
        }
    }

    public void SpriteBounceL()
    {
        stopLeftCoroutine();
        if (!leftCoroutineRunning)
        {
            leftCoroutine = StartCoroutine(bounceSpriteFull(LeftSprite, "left", .3f));
        }
    }

    public void SpriteBounceC()
    {
        stopCenterCoroutine();
        if (!centerCoroutineRunning)
        {
            centerCoroutine = StartCoroutine(bounceSpriteFull(CenterSprite, "center", .3f));
        }
    }

    public void SpriteBounceR()
    {
        stopRightCoroutine();
        if (!rightCoroutineRunning)
        {
            rightCoroutine = StartCoroutine(bounceSpriteFull(RightSprite, "right", .3f));
        }
    }

    public void SpriteMoveL(int units, float time)
    {
        stopLeftCoroutine();
        if (!leftCoroutineRunning)
        {
            leftCoroutine = StartCoroutine(moveSprite(LeftSprite, units, time));
        }
    }

    public void SpriteMoveC(int units, float time)
    {
        stopCenterCoroutine();
        if (!centerCoroutineRunning)
        {
            centerCoroutine = StartCoroutine(moveSprite(CenterSprite, units, time));
        }
    }

    public void SpriteMoveR(int units, float time)
    {
        stopRightCoroutine();
        if (!rightCoroutineRunning)
        {
            rightCoroutine = StartCoroutine(moveSprite(RightSprite, units, time));
        }
    }

    //*****Private Methods*****

    // Sprite configuration helpers

    private void setCorrespondingCharacter(SpriteRenderer sR, string charName)
    {
        setCurrentSpritesRef(charName);
        sR.sprite = currentSpritesRef[0]; //temp code, just set the spriterenderer's sprite component to ind 0 of whatever sprites by default
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

            // Side Characters

            case GameConstants.BLONDE_FRIEND:
                currentSpritesRef = BlondeFriendSprites;
                break;

            case GameConstants.HISTORY_TEACHER:
                currentSpritesRef = HistoryTeacherSprites;
                break;

            //NPCs
            case GameConstants.BLOB_NPC:
                currentSpritesRef = NPCSprites;
                break;

            case GameConstants.STUDENT_NPC:
                currentSpritesRef = StudentNPCSprites;
                break;

            //default
            default:
                Sprite image = null;
                Sprite[] NoneSprite = { image };
                currentSpritesRef = NoneSprite;
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


    // sprite action helpers
    // resetting sprite positions
    private IEnumerator resetAllPositions()
    {
        RightSprite.transform.position = GameConstants.RIGHT_SPRITE_POS;
        CenterSprite.transform.position = GameConstants.CENTER_SPRITE_POS;
        LeftSprite.transform.position = GameConstants.LEFT_SPRITE_POS;
        yield return null;
    }

    private IEnumerator resetLeftPosition()
    {
        LeftSprite.transform.localPosition = GameConstants.LEFT_SPRITE_POS;
        yield return null;
    }

    private IEnumerator resetCenterPosition()
    {
        CenterSprite.transform.localPosition = GameConstants.CENTER_SPRITE_POS;
        yield return null;
    }

    private IEnumerator resetRightPosition()
    {
        RightSprite.transform.localPosition = GameConstants.RIGHT_SPRITE_POS;
        yield return null;
    }


    // stopping coroutines

    private void stopLeftCoroutine()
    {
        if (leftCoroutineRunning && leftActive)
        {
            StopCoroutine(leftCoroutine);
            leftCoroutineRunning = false;
        }
    }

    private void stopCenterCoroutine()
    {
        if (centerCoroutineRunning && centerActive)
        {
            StopCoroutine(centerCoroutine);
            centerCoroutineRunning = false;
        }
    }

    private void stopRightCoroutine()
    {
        if (rightCoroutineRunning && rightActive)
        {
            StopCoroutine(rightCoroutine);
            rightCoroutineRunning = false;
        }
    }

    // queueing the correct position resets to some provided coroutine queue
    private void queuePositionReset(Queue<IEnumerator> q, string spritePos)
    {
        switch (spritePos)
        {
            case "left":
                q.Enqueue(resetLeftPosition());
                break;
            case "center":
                q.Enqueue(resetCenterPosition());
                break;
            case "right":
                q.Enqueue(resetRightPosition());
                break;
            default:
                q.Enqueue(resetAllPositions());
                break;
        }
    }


    // set coroutineRunning bool for the given spirte at spritePos to true
    private void setCoroutineRunning(string spritePos)
    {
        switch (spritePos)
        {
            case "left":
                leftCoroutineRunning = true;
                break;
            case "center":
                centerCoroutineRunning = true;
                break;
            case "right":
                rightCoroutineRunning = true;
                break;
            default:
                leftCoroutineRunning = true;
                centerCoroutineRunning = true;
                rightCoroutineRunning = true;
                break;
        }
    }


    private void setCoroutineOver(string spritePos)
    {
        switch (spritePos)
        {
            case "left":
                leftCoroutineRunning = false;
                break;
            case "center":
                centerCoroutineRunning = false;
                break;
            case "right":
                rightCoroutineRunning = false;
                break;
            default:
                // i don't want to overestimate which coroutines have stopped running
                // but also I don't want the whole program to crash in case of a typo
                // anyway the default case will do nothing.
                break;
        }
    }

    // shaking
    private IEnumerator shakeSpriteFull(GameObject sprite, string spritePos, float transTime1, float transTime2, float transTime3)
    {
        //check which coroutine is running
        setCoroutineRunning(spritePos);

        Queue<IEnumerator> shakeQueue = new Queue<IEnumerator>();
        shakeQueue.Enqueue(shakeSpriteStart(sprite, transTime1));
        shakeQueue.Enqueue(shakeSpriteMid(sprite, transTime2));
        shakeQueue.Enqueue(shakeSpriteEnd(sprite, transTime3));
        shakeQueue.Enqueue(shakeSpriteStart(sprite, transTime1));
        shakeQueue.Enqueue(shakeSpriteMid(sprite, transTime2));
        shakeQueue.Enqueue(shakeSpriteEnd(sprite, transTime3));
        shakeQueue.Enqueue(shakeSpriteStart(sprite, transTime1));
        shakeQueue.Enqueue(shakeSpriteMid(sprite, transTime2));
        shakeQueue.Enqueue(shakeSpriteEnd(sprite, transTime3));

        // check which sprite position to reset afterward, and enqueue the corresponding sprite position reset.
        queuePositionReset(shakeQueue, spritePos);

        // run the coroutine queue
        while (shakeQueue.Count > 0)
        {
            yield return StartCoroutine(shakeQueue.Dequeue());
        }

        yield return null; // tell the coroutine to execute next time it is eligible
        setCoroutineOver(spritePos); // update the bool to reflect that the coroutine is over.
    }

    private IEnumerator shakeSpriteStart(GameObject sprite, float transTime)
    {
        Vector3 temppos = sprite.transform.position;
        Vector3 tempmin = new Vector3(temppos.x - .05f, temppos.y, temppos.z);

        sprite.LeanMove(tempmin, transTime).setEase(LeanTweenType.easeOutElastic);
        yield return new WaitForSeconds(transTime);
    }

    private IEnumerator shakeSpriteMid(GameObject sprite, float transTime)
    {
        Vector3 temppos = sprite.transform.position;
        Vector3 tempmax = new Vector3(temppos.x + .1f, temppos.y, temppos.z);

        sprite.LeanMove(tempmax, transTime).setEase(LeanTweenType.easeInOutElastic);
        yield return new WaitForSeconds(transTime);
    }

    private IEnumerator shakeSpriteEnd(GameObject sprite, float transTime)
    {
        Vector3 temppos = sprite.transform.position;
        Vector3 tempmin = new Vector3(temppos.x - .05f, temppos.y, temppos.z);

        sprite.LeanMove(tempmin, transTime).setEase(LeanTweenType.easeInElastic);
        yield return new WaitForSeconds(transTime);
    }


    // bouncing
    private IEnumerator bounceSpriteFull(GameObject sprite, string spritePos, float bounceTime)
    {
        setCoroutineRunning(spritePos);

        Queue<IEnumerator> bounceQueue = new Queue<IEnumerator>();
        bounceQueue.Enqueue(bounceSprite(sprite, bounceTime));
        queuePositionReset(bounceQueue, spritePos);

        // run the coroutine queue
        while (bounceQueue.Count > 0)
        {
            yield return StartCoroutine(bounceQueue.Dequeue());
        }
        
        yield return null;
        setCoroutineOver(spritePos);

    }

    private IEnumerator bounceSprite(GameObject sprite, float bounceTime)
    {
        Vector3 temppos = sprite.transform.position;
        Vector3 bouncepos = new Vector3(temppos.x, temppos.y + .2f, temppos.z);
        sprite.LeanMove(bouncepos, bounceTime).setEase(LeanTweenType.easeOutBounce);
        yield return new WaitForSeconds(bounceTime);
    }


    // moving
    private IEnumerator moveSprite(GameObject sprite, int units, float moveTime)
    {
        Vector3 temppos = sprite.transform.position;
        Vector3 movepos = new Vector3(temppos.x + units * .05f, temppos.y, temppos.z);
        sprite.LeanMove(movepos, moveTime);
        yield return new WaitForSeconds(moveTime + .1f); // leave some room
    }

}
