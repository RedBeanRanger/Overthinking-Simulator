using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Popup Controller", menuName = "ScriptableObjects/Popup Controller SO")]
public class PopupController : ScriptableObject
{
    public GameObject PopupObject;
    private TextMeshProUGUI popupText;

    void OnEnable()
    {
        popupText = PopupObject.GetComponent<TextMeshProUGUI>();
    }
}
