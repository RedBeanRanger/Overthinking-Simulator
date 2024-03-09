using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// define struct for Option
public struct Option
{
    public List<Criteria> bounds;

    // list of variables to check if true
    public List<VarCondition> variables;
    public int nextSceneIndex; // default to 0

}

// decide next game scene given current scene
// should be able to input a list of criteria for the bars Sbar, Hbar, Pbar, Abar
// either larger than or smaller than for each value
// and what corresponds to an index in the next game scene

// define struct for Criteria
public struct Criteria
{
    public string bar; // should be S, H, P, or A,
    public int lowerbound; // default 0
    public int upperbound; // default 100
}

// define struct for VarCondition

public struct VarCondition
{
    public string variable;

    public string type = "bool"; // should be bool, int, float, or string

    // define condition
    public bool equals = true; // if true then it returns true if the value of the variable equal to value
    // TODO change to operator to allow for more than just equals like greater than, less than, etc.
    public string value = "true";

    // variable called 'variable' of type 'type' should be 'equals' to 'value'
    // variable called 'thiefLevel' of type 'int' equals 5 should be 'true' then return true else false

}

[CreateAssetMenu(fileName = "Game Scene Controller SO", menuName = "ScriptableObjects/Game Scene Controller SO")]

public static class Globals
{
    // dictionary of all game variables
    public static Dictionary<string, bool> boolVariables = new Dictionary<string, bool>();
    public static Dictionary<string, int> intVariables = new Dictionary<string, int>();
    public static Dictionary<string, float> floatVariables = new Dictionary<string, float>();
    public static Dictionary<string, string> stringVariables = new Dictionary<string, string>();


    // add a variable to the dictionary
    public static void SetVariable(string dict, string variableName, bool boolValue = false, int intValue = 0, float floatValue = 0.0f, string stringValue = "")
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

    // these game scenes will need to be defined 
    // in the inspector(?)

    public GameSceneData CurrentGameSceneData;
    public int CurrentGameSceneIndex;


    // game scene dictionary
    // name to game scene data
    public Dictionary<string, GameSceneData> gameSceneDict = new Dictionary<string, GameSceneData>();
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
                gameSceneDict.Add(GameScenes[i].Name, GameScenes[i]);
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

    public void UpdateGameSceneNextScene(int buttonIndex)
    {
        // each game scene will have at most 4 buttons
        // each button has at most 4 possible next scenes
        // each button has a list of Options, each Option leads to a different next scene

    }
    


    // determine if the current game scene data meets the criteria
    public bool VerifyCriteria(Criteria c)
    {
        switch (c.bar)
        {
            case "S":
                if (CurrentGameSceneData.SBar >= c.lowerbound && CurrentGameSceneData.Sbar <= c.upperbound)
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
    public bool VerifyCondition(VarCondition vc)
    {
        switch (vc.type)
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
                    if (vc.equals)
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
                    if (vc.equals)
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
                    if (vc.equals)
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

    // reuse the decider function for setting variables as a value
    // if the option is met, set the variable to the value
    public void decideVariable(List<Option> options, List<string> values, string variable, string type)
    {
        foreach (int i; i < options.Count; i++)
        {
            if (VerifyOption(options[i]))
            {
                switch (options[i].variables[0].type)
                {
                    case "bool":
                        // catch if the value is not a bool
                        
                        if (values[i] != "true" && values[i] != "false")
                        {
                            Debug.LogWarning("Warning: No valid bool value. Check if the value was valid.");
                            break;
                        }
                        Globals.SetVariable("bool", variable, boolValue: bool.Parse(values[i]));
                        break;
                    case "int":
                        // catch if the value is not an int
                        if (!int.TryParse(values[i], out int n))
                        {
                            Debug.LogWarning("Warning: No valid int value. Check if the value was valid.");
                            break;
                        }
                        Globals.SetVariable("int", variable, intValue: int.Parse(values[i]));
                        break;
                    case "float":
                        // catch if the value is not a float
                        if (!float.TryParse(values[i], out float n))
                        {
                            Debug.LogWarning("Warning: No valid float value. Check if the value was valid.");
                            break;
                        }
                        Globals.SetVariable("float", variable, floatValue: float.Parse(values[i]));
                        break;
                    case "string":
                        Globals.SetVariable("string", variable, stringValue: values[i]);
                        break;
                    default:
                        Debug.LogWarning("Warning: No valid type. Check if the type was valid.");
                        break;    
                        
                }
            break;
            }

        }
    }

    // parse string like this into an Option
    // "S:20-40, H:30-50,P:40-60,A:50-70;  metJae:bool:true,ateApple:int:5;1"
    // OTHERWISE Option([Criteria(S,0,30), Criteria(H,30,50), Criteria(A,50,70)], [VarCondition(metJae,bool,true), VarCondition(ateApple,int,5)], 1)
    // ignore spaces
    // split lists by ;

    public Option ParseOption(string s)
    {
        Option o = new Option();
        // remove spaces from string
        s = s.Replace(" ", string.Empty);
        string[] parts = s.Split(';');
        string[] bounds = parts[0].Split(',');
        foreach (string b in bounds)
        {
            string[] bound = b.Split(':');
            Criteria c = new Criteria();
            c.bar = bound[0]
            string[] range = bound[1].Split('-');
            c.lowerbound = int.Parse(range[0]);
            c.upperbound = int.Parse(range[1]);
            o.bounds.Add(c);
        }
        string[] variables = parts[1].Split(',');
        foreach (string v in variables)
        {
            string[] variable = v.Split(':');
            VarCondition vc = new VarCondition();
            vc.variable = variable[0];
            vc.type = variable[1];
            vc.value = variable[2];
            o.variables.Add(vc);
        }
        o.nextSceneIndex = int.Parse(parts[2]);
        return o;
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
