using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Scene Controller SO", menuName = "ScriptableObjects/Scene Controller SO")]
public class SceneController : ScriptableObject
{
    //*****public variables*****//
    public GameSceneData[] GameScenes;
    public GameSceneData CurrentGameSceneData;
    public int CurrentGameSceneIndex;

    //*****private variables*****//
    private string[] gameSceneNames;

    //*****public methods*****//
    void OnEnable()
    {
        // get all the sceneNames available
        if (GameScenes != null)
        {
            gameSceneNames = new string[GameScenes.Length];
            for (int i = 0; i < GameScenes.Length; i++)
            {
                gameSceneNames[i] = GameScenes[i].Name;
            }
        }

        CurrentGameSceneIndex = 0;
        CurrentGameSceneData = GameScenes[CurrentGameSceneIndex];
    }

    public void UpdateGameSceneData()
    {
        if (IsThereMoreScenes())
        {
            CurrentGameSceneIndex = getNextGameSceneIndex();
            CurrentGameSceneData = getGameSceneData();
        }
    }

    public bool IsThereMoreScenes()
    {
        if (CurrentGameSceneData.NextScene != null)
        {
            return true;
        }
        return false;
    }

    //*****private methods*****//
    // get the next scene index
    private int getNextGameSceneIndex()
    {
        string nextGameSceneName = CurrentGameSceneData.NextScene.Name;
        int nextGameSceneInd = Array.IndexOf(gameSceneNames, nextGameSceneName); //get the next scene's index
        if (nextGameSceneInd == 0)
        {
            Debug.LogWarning("Warning: Next Game Scene is set to GameScenes[0]. Check if a valid next game scene name existed.");
        }
        return nextGameSceneInd;
    }

    //get the game scene data given Current Game Scene Index
    private GameSceneData getGameSceneData()
    {
        return GameScenes[CurrentGameSceneIndex];
    }

    //get the game scene given any int index
    private GameSceneData getGameSceneDataByIndex(int index)
    {
        return GameScenes[index];
    }


}
