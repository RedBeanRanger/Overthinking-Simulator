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
    public ButtonOutcome [] buttonOutcomes;

    // OR 
    // we can have 4 different lists of possible next scenes, one for each button

}

// firstbutton = ButtonOutcome(0, [Option(), Option()], [GameSceneData1, GameSceneData2])
// class storing options of possible outcomes of a button 
public class ButtonOutcome
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
