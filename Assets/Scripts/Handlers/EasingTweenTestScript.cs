using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasingTweenTestScript : MonoBehaviour
{
    public GameObject ImageBlock;
    private Image image;
    private RectTransform trans;

    // Start is called before the first frame update
    void Start()
    {
        image = ImageBlock.GetComponent<Image>();
        trans = ImageBlock.GetComponent<RectTransform>();
        ImageBlock.transform.position = new Vector3(0f, Screen.height + trans.sizeDelta.y, 0f);
        RandomizeColor();

        TransitionStripesIn();
        //TransitionStripesOut();
    }

    public void RandomizeColor()
    {
        int color = Random.Range(0, 3); //max exclusive, so numbers are 0, 1 and 2
        switch (color)
        {
            case 0:
                image.color = new Color32(132, 232, 253, 255); //blue
                break;
            case 1:
                image.color = new Color32(255, 169, 116, 255); //orange
                break;
            case 2:
                image.color = new Color32(255, 188, 192, 255); //pink
                break;
        }
    }

    public void TransitionStripesIn()
    {
        LeanTween.moveY(ImageBlock.GetComponent<RectTransform>(), -Screen.height - trans.sizeDelta.y, 4f);
    }


}
