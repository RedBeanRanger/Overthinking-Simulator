using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Game Scene Controller SO", menuName = "ScriptableObjects/Game Scene Controller SO")]
public class GameSceneController : ScriptableObject
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
        if (IsThereMoreGameScenes())
        {
            CurrentGameSceneIndex = getNextGameSceneIndex();
            CurrentGameSceneData = getGameSceneData();
        }
    }

    public bool IsThereMoreGameScenes()
    {
        if (CurrentGameSceneData.NextScene != null && GameScenes.Length > 1)
        {
            return true;
        }
        return false;
    }


    // test method

    public void UpdateGameSceneNextScene(bool willMeetJae)
    {
        if (!willMeetJae)
        {
            if (GameScenes[0].Name == "Scene1")
            {
                GameScenes[0].NextScene = GameScenes[0].PossibleNextScenes[0];
            }
        }
        if (willMeetJae)
        {
            if (GameScenes[0].Name == "Scene0")
            {
                GameScenes[0].NextScene = GameScenes[0].PossibleNextScenes[1];
            }
        }
    }

    public void UpdateGameSceneNextScene(int node)
    {
        // update next game scene node to int node
    }

    // decider function
    //return 0,1,2,3
    /*
    // TUMBLY ADDITION
    public void decider(string dependson, index, lowerbound, upperbound, booleanvallist)

    */


    //*****private methods*****//
    // get the next scene index
    private int getNextGameSceneIndex()
    {
        string nextGameSceneName = CurrentGameSceneData.NextScene.Name;
        int nextGameSceneInd = Array.IndexOf(gameSceneNames, nextGameSceneName); //get the next scene's index
        if (nextGameSceneInd == -1)
        {
            Debug.LogWarning("Warning: No valid nextGameSceneInd. Check if the next game scene name was valid. Next Game Scene will be set to GameScenes[0].");
            return 0;
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
