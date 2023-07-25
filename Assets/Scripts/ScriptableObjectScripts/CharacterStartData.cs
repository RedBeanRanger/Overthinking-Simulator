using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character Start Data", menuName = "ScriptableObjects/CharacterStartData")]
public class CharacterStartData : ScriptableObject
{
    public int DefaultSBarValue;
    public int DefaultHBarValue;
    public int DefaultPBarValue;
    public int DefaultABarValue;
}
