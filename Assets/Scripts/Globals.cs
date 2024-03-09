using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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