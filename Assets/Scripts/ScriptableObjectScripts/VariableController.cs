using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Variable Controller SO", menuName = "ScriptableObjects/Variable Controller SO")]
public class VariableController : ScriptableObject
{
    // Types of things I'd want to be able to do:
    // Automatically update and store variables when certain conditions are met, so that GameSceneController can read and fetch the correct Node
    // I think that means I will have to listen for certain events maybe
    // I need a way to handle variables that are linked to choices, and a way to handle variables that are linked to stats.

    // Store variables that give information on how plotlines are progressing


    // ***** Public Fields *****
    // variables
    public bool TestVar = true;




}
