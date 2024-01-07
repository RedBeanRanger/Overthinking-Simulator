using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class GameVars
{
    //*****public fields*****//
    public Dictionary<string, Ink.Runtime.Object> InkVariables { get; private set; } // right now all of the Variables passed into ink are stored in one massive dictionary (melt)


    //*****constructor*****//
    // initialise the dictionary with all the variables in the GlobalVars ink file.
    public GameVars(string filePath)
    {
        string inkFileContents = File.ReadAllText(filePath);

        // compile the file contents into a story object so that we can use Ink.Runtime.Objects
        Ink.Compiler compiler = new Ink.Compiler(inkFileContents);
        Story globalVarsStory = compiler.Compile();

        // initialise the InkVariables dictionary - for every var in GlobalVars, add its name and value.
        InkVariables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVarsStory.variablesState)
        {
            Ink.Runtime.Object value = globalVarsStory.variablesState.GetVariableWithName(name);
            InkVariables.Add(name, value);

            Debug.Log("init: " + name + "with value " + value);
        }
    }

    //*****public methods*****//
    public void StartListening(Story story)
    {
        //basically tie every variable in InkVariables to a variable in the story. Should only run once.
        variablesToStory(story);

        // listen for variable changed event
        story.variablesState.variableChangedEvent += variableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= variableChanged;
    }

    // modify the ink variable with given name to the given value
    public void ModifyInkVar(Story story, string name, int value)
    {
        story.variablesState[name] = value;
        Debug.Log("Modified " + name + " to " + value);
    }

    public void ModifyInkVar(Story story, string name, bool value)
    {
        story.variablesState[name] = value;
        Debug.Log("Modified " + name + " to " + value);
    }

    public void ModifyInkVar(Story story, string name, string value)
    {
        story.variablesState[name] = value;
        Debug.Log("Modified " + name + " to " + value);
    }

    //*****private methods*****//

    private void variableChanged(string name, Ink.Runtime.Object value)
    {
        // every time the variables are changed, we update the dictionary - im NOT SURE if this is the best way to do it AHAHAA
        if (InkVariables.ContainsKey(name))
        {
            InkVariables.Remove(name);
            InkVariables.Add(name, value);
        }
        Debug.Log("Var name " + name + " value " + value);
    }

    private void variablesToStory(Story story)
    {
        foreach(KeyValuePair<string, Ink.Runtime.Object> var in InkVariables)
        {
            story.variablesState.SetGlobal(var.Key, var.Value);
        }
    }
}
