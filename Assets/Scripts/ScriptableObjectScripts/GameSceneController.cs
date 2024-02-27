using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Game Scene Controller SO", menuName = "ScriptableObjects/Game Scene Controller SO")]

public static class Globals
{
    // dictionary of all game variables
    public static Dictionary<string, bool> boolVariables = new Dictionary<string, bool>();
    public static Dictionary<string, int> intVariables = new Dictionary<string, int>();
    public static Dictionary<string, float> floatVariables = new Dictionary<string, float>();
    public static Dictionary<string, string> stringVariables = new Dictionary<string, string>();


    // add a variable to the dictionary
    public static void AddVariable(string dict, string variableName, bool boolValue = false, int intValue = 0, float floatValue = 0.0f, string stringValue = "")
    {
        switch (dict)
        {
            case "bool":
                if (boolVariables.ContainsKey(variableName))
                {
                    boolVariables[variableName] = boolValue;
                }
                else
                {
                    boolVariables.Add(variableName, boolValue);
                }
                break;
            case "int":
                if (intVariables.ContainsKey(variableName))
                {
                    intVariables[variableName] = intValue;
                }
                else
                {
                    intVariables.Add(variableName, intValue);
                }
                break;
            case "float":
                if (floatVariables.ContainsKey(variableName))
                {
                    floatVariables[variableName] = floatValue;
                }
                else
                {
                    floatVariables.Add(variableName, floatValue);
                }
                break;
            case "string":
                if (stringVariables.ContainsKey(variableName))
                {
                    stringVariables[variableName] = stringValue;
                }
                else
                {
                    stringVariables.Add(variableName, stringValue);
                }
                break;
            default:
                Debug.LogWarning("Warning: No valid dictionary. Check if the dictionary was valid.");
                break;
        }
    }
}




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
            GameScenes[0].NextScene = GameScenes[0].PossibleNextScenes[0];
        }
        if (willMeetJae)
        {
            GameScenes[0].NextScene = GameScenes[0].PossibleNextScenes[1];
        }
    }

    public void UpdateGameSceneNextScene(int node)
    {
        // update next game scene node to int node
    }

    // decide next game scene given current scene
    // should be able to input a list of criteria for the bars Sbar, Hbar, Pbar, Abar
    // either larger than or smaller than for each value
    // and what corresponds to an index in the next game scene

    // define struct for Criteria
    struct Criteria
    {
        public string bar; // should be S, H, P, or A,
        public int lowerbound = 0;
        public int upperbound = 100;
    }

    // determine if the current game scene data meets the criteria
    public bool VerifyCriteria(Criteria c)
    {
        switch c.bar
        {
            case "S":
                if (CurrentGameSceneData.Sbar >= c.lowerbound && CurrentGameSceneData.Sbar <= c.upperbound)
                {
                    return true;
                }
                break;
            case "H":
                if (CurrentGameSceneData.Hbar >= c.lowerbound && CurrentGameSceneData.Hbar <= c.upperbound)
                {
                    return true;
                }
                break;
            case "P":
                if (CurrentGameSceneData.Pbar >= c.lowerbound && CurrentGameSceneData.Pbar <= c.upperbound)
                {
                    return true;
                }
                break;
            case "A":
                if (CurrentGameSceneData.Abar >= c.lowerbound && CurrentGameSceneData.Abar <= c.upperbound)
                {
                    return true;
                }
                break;
            default:
                Debug.LogWarning("Warning: No valid criteria. Check if the criteria bar was valid.");
                return false;
        }
        return false;
    }

    // define struct for VarCondition
    struct VarCondition
    {
        public string variable;

        public string type = "bool"; // should be bool, int, float, or string

        // define condition
        public bool equals = true;

        public string value = "true";
    }

    public bool VerifyCondition(VarCondition vc)
    {
        switch vc.type
        {
            case "bool":
                if (Globals.boolVariables.ContainsKey(vc.variable))
                {
                    if (Globals.boolVariables[vc.variable] == vc.equals)
                    {
                        return true;
                    }
                }
                break;
            case "int":
                if (Globals.intVariables.ContainsKey(vc.variable))
                {
                    if vc.equals
                    {
                        if (Globals.intVariables[vc.variable] == int.Parse(vc.value))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (Globals.intVariables[vc.variable] != int.Parse(vc.value))
                        {
                            return true;
                        }
                    }
                }
                break;
            case "float":
                if (Globals.floatVariables.ContainsKey(vc.variable))
                {
                    if vc.equals
                    {
                        if (Globals.floatVariables[vc.variable] == float.Parse(vc.value))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (Globals.floatVariables[vc.variable] != float.Parse(vc.value))
                        {
                            return true;
                        }
                    }
                }
                break;
            case "string":
                if (Globals.stringVariables.ContainsKey(vc.variable))
                {
                    if vc.equals
                    {
                        if (Globals.stringVariables[vc.variable] == vc.value)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (Globals.stringVariables[vc.variable] != vc.value)
                        {
                            return true;
                        }
                    }
                }
                break;
            default:
                Debug.LogWarning("Warning: No valid type. Check if the type was valid.");
                return false;

        }
        return false;
                    
    }


    // define struct for Option
    struct Option
    {
        public List<Criteria> bounds;

        // list of variables to check if true
        public List<VarCondition> variables;
        public int nextSceneIndex = 0;

    }

    // verify option
    public bool VerifyOption(Option o)
    {
        foreach (Criteria c in o.bounds)
        {
            if (!VerifyCriteria(c))
            {
                return false;
            }
        }
        foreach (VarCondition vc in o.variables)
        {
            if (!VerifyCondition(vc))
            {
                return false;
            }
        }

        return true;
    }



    // decider function
    //return 0,1,2,3
    
    // TUMBLY ADDITION
    // parameter is list of criteria 
    public void decider(List<Option> options)
    {
        foreach (Option o in options)
        {
            if (VerifyOption(o))
            {
                CurrentGameSceneIndex = o.nextSceneIndex;
                CurrentGameSceneData = getGameSceneDataByIndex(CurrentGameSceneIndex);
                return;
            }
        }
        // else, default to fourth option
        CurrentGameSceneIndex = 3;
        CurrentGameSceneData = getGameSceneDataByIndex(CurrentGameSceneIndex);
    }
    

    


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
