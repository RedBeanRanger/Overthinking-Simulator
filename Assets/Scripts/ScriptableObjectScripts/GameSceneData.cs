using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Game Scene Data", menuName = "ScriptableObjects/GameSceneData")]

// some scenes will be reusable, so we will need to store the data in a scriptable object
// this will allow us to reuse the same scene data in different parts of the game
public class GameSceneData : ScriptableObject
{
    public string Name;
    public Sprite BackgroundSprite;
    public TextAsset InkTextJSON;
    public GameSceneData NextScene;
    public GameSceneData [] PossibleNextScenes;


    // we can store the button outcomes in the game scene data
    public ButtonOutcome [] ButtonOutcomes;
    public GameSceneData DefaultNextScene;

    // we want to:
    // Event system to check which button is pressed - when the

    // Write a check: Is the scene loaded with all the button outcomes?
    // Possibilities:
        // - Load all the button outcomes at once in the beginning
        // - Load the button outcomes when you get them
    
    // Overhaul GameSceneData - Where to define it all? - 
    // Write a script to serialize scriptable object GameSceneData in script
    // Or make GameSceneData a normal class controlled by GameSceneDataController - GameHandler would never have to talk to GameSceneData anyway (maybe?)


    // OR 
    // we can have 4 different lists of possible next scenes, one for each button

}


[CreateAssetMenu(fileName = "Button Outcome", menuName = "ScriptableObjects/ButtonOutcome")]
// firstbutton = ButtonOutcome(0, [Option(), Option()], [GameSceneData1, GameSceneData2])
// class storing options of possible outcomes of a button 
public class ButtonOutcome : ScriptableObject
{
    public int buttonIndex;
    public List<Option> options;
    public GameSceneData [] PossibleNextScenes;

    public ButtonOutcome(int buttonIndex, List<Option> options, GameSceneData [] PossibleNextScenes)
    {
        this.buttonIndex = buttonIndex;
        this.options = options;
        this.PossibleNextScenes = PossibleNextScenes;
    }

}
