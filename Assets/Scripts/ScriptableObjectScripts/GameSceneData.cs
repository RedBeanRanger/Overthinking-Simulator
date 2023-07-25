using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Game Scene Data", menuName = "ScriptableObjects/GameSceneData")]
public class GameSceneData : ScriptableObject
{
    public string Name;
    public Sprite BackgroundSprite;
    public TextAsset InkTextJSON;
    public GameSceneData NextScene;

}
