using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Default Data", menuName = "ScriptableObjects/Character Default Data")]
public class CharacterDefaultData : ScriptableObject
{
    //maximum values of each bar
    public int SocialMax;
    public int HappinessMin;
    public int HappinessMax;
    public int PersonalMax;
    public int AnxietyMax;

    public int AnxietyThreshold;
    public int BaselineHappiness;

    public int StartingSocial;
    public int StartingHappiness;
    public int StartingAnxiety;
    public int StartingPersonal;
    public float StartingMoney;

    // Modifier: how fast characters HEAL from damaged reputations
    // BELOVED raate is 2
    // Average rate is 1
    // Hated rate is 0.5
    public float ForgivenessRate;

}
