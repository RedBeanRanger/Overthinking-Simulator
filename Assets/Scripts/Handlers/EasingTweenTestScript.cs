using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasingTweenTestScript : MonoBehaviour
{

    //***** Public Vars *****//
    public GameObject ImageBlock1;
    public GameObject ImageBlock2;
    public float TransitionTime; // wait for seconds
    public bool IsInTransition; // whether or not we are currently in transition

    //***** Private Vars *****//
    private Image image1;
    private Image image2;

    private RectTransform trans1;
    private RectTransform trans2;


    //***** Public Methods *****//
    public void OnCallStart()
    {
        image1 = ImageBlock1.GetComponent<Image>();
        trans1 = ImageBlock1.GetComponent<RectTransform>(); // currently not used by anything

        image2 = ImageBlock2.GetComponent<Image>();
        trans2 = ImageBlock2.GetComponent<RectTransform>();

        // set positions to out of screen
        ImageBlock1.transform.position = new Vector3(0f, Screen.height, 0f);
        ImageBlock2.transform.position = new Vector3(0f, -Screen.height, 0f);

        //randomizeColor();
        //TransitionIn();
        //StartCoroutine(yWipeIn());
        //TransitionOut();
    }


    //*****Proxy methods to run a full transition, can be called by GameHandler
    // transition events are listened for by GameHandler onStart.
    public void RunRandomYTransition()
    {
        int num = UnityEngine.Random.Range(0, 2); //max exclusive
        switch (num)
        {
            case 0:
                RunYWipe();
                break;
            case 1:
                RunYDualBounce();
                break;
            default:
                RunYWipe();
                break;
        }
    }

    public void RunYWipe()
    {
        ImageBlock1.transform.position = new Vector3(0f, Screen.height, 0f);
        randomizeColor(image1);
        if (!IsInTransition)
        {
            StartCoroutine(YWipeFull());
        }
    }

    public void RunYDualBounce()
    {
        ImageBlock1.transform.position = new Vector3(0f, Screen.height, 0f);
        ImageBlock2.transform.position = new Vector3(0f, -Screen.height, 0f);
        randomizeColor(image1);
        randomizeColor(image2);
        if (!IsInTransition)
        {
            StartCoroutine(YDualBounceFull());
        }
    }


    //*****Transition Coroutines - public coroutines that run a combination of sub coroutines for a full scene transition
    // Not called by GameHandler (but could potentially be, if ever the need surfaces)
    // Note that these can't be stopped with StopCoroutine, but sub coroutines can with some code.
    public IEnumerator YWipeFull()
    {
        IsInTransition = true;
        Queue<IEnumerator> transitionQueue = new Queue<IEnumerator>();
        transitionQueue.Enqueue(yWipeIn());
        transitionQueue.Enqueue(yWipeOut());
        while (transitionQueue.Count > 0)
        {
            yield return StartCoroutine(transitionQueue.Dequeue());
        }
        yield return null;
        IsInTransition = false;
    }

    public IEnumerator YDualBounceFull()
    {
        IsInTransition = true;
        Queue<IEnumerator> transitionQueue = new Queue<IEnumerator>();
        transitionQueue.Enqueue(yDualBounceIn());
        transitionQueue.Enqueue(yDualBounceOut());
        while (transitionQueue.Count > 0)
        {
            yield return StartCoroutine(transitionQueue.Dequeue());
        }
        yield return null;
        IsInTransition = false;
    }

    //***** Private Methods *****//

    private void randomizeColor(Image img)
    {
        int color = UnityEngine.Random.Range(0, 3); //max exclusive, so numbers are 0, 1 and 2
        switch (color)
        {
            case 0:
                img.color = new Color32(132, 232, 253, 255); //blue
                break;
            case 1:
                img.color = new Color32(255, 169, 116, 255); //orange
                break;
            case 2:
                img.color = new Color32(255, 188, 192, 255); //pink
                break;
        }
    }


    // Sub Coroutines, cannot be directly run by other programs.
    // I added some buffering time for each coroutine
    private IEnumerator yWipeIn()
    {
        ImageBlock1.LeanMoveY(0f, TransitionTime);
        yield return new WaitForSeconds(TransitionTime + .5f);
    }
    
    private IEnumerator yWipeOut()
    {
        ImageBlock1.LeanMoveY(-Screen.height, TransitionTime);
        yield return new WaitForSeconds(TransitionTime + .2f);
    }

    private IEnumerator yDualBounceIn()
    {
        ImageBlock1.LeanMoveY(Screen.height/2, TransitionTime).setEase(LeanTweenType.easeOutBounce);
        ImageBlock2.LeanMoveY(-Screen.height/2, TransitionTime).setEase(LeanTweenType.easeOutBounce);
        yield return new WaitForSeconds(TransitionTime + .5f);
    }

    private IEnumerator yDualBounceOut()
    {
        ImageBlock1.LeanMoveY(Screen.height, TransitionTime).setEase(LeanTweenType.easeInCubic);
        ImageBlock2.LeanMoveY(-Screen.height, TransitionTime).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(TransitionTime +.2f);
    }

    /*
    public void TransitionIn()
    {
        //LeanTween.moveY(ImageBlock1.GetComponent<RectTransform>(), -Screen.height*2, 4f);
        ImageBlock1.LeanMoveY(0f, TransitionTime);
    }
    public void TransitionOut()
    {
        ImageBlock1.LeanMoveY(-Screen.height - 30, TransitionTime);
    }
    */


}
