using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager
{
    // Configuration Manager: Assigns and fetches input keys.



    // ***** Public Variables/Properties *****

    public Dictionary<string, KeyCode> ActionInputs { get; set; }
    public Dictionary<string, KeyCode> DirectionInputs { get; set; }



    // ***** Private Variables *****

    private readonly Dictionary<string, KeyCode> _defaultActionInputs = new Dictionary<string, KeyCode>() {
        {"Action Confirm", KeyCode.J}, {"Action Skip", KeyCode.Space}, {"Action Escape", KeyCode.Escape}};
    private readonly Dictionary<string, KeyCode> _defaultDirectionInputs = new Dictionary<string, KeyCode>() {
        {"Direction Up", KeyCode.W}, {"Direction Down", KeyCode.S}, {"Direction Left", KeyCode.A}, {"Direction Right", KeyCode.D}};



    //*****Constructor Method*****
    // Assign default action inputs as current inputs on initialization when constructor method is called.
    public ConfigManager()
    {
        ActionInputs = new Dictionary<string, KeyCode>();
        DirectionInputs = new Dictionary<string, KeyCode>();

        foreach (KeyValuePair<string, KeyCode> actionPair in _defaultActionInputs)
        {
            ActionInputs.Add(actionPair.Key, actionPair.Value);
        }

        foreach (KeyValuePair<string, KeyCode> directionPair in _defaultDirectionInputs)
        {
            DirectionInputs.Add(directionPair.Key, directionPair.Value);
        }

    }



    //*****Public Methods*****

    // Set Default- Set current keybindings as default. Assume the keys in the dictionaries are always matching.
    public void SetDefault()
    {
        // Assume the keys are always matching.
        ActionInputs = _defaultActionInputs;
        DirectionInputs = _defaultDirectionInputs;
    }


}
