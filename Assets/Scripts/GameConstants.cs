using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants
{
    // Tags in Inky
    public const string ACTIVE_CHARACTER = "Active"; // specify left, center, or right
    public const string DISPLAY_NAME = "Name"; // specify name to be rendered

    public const string EXPRESSION_TAG = "Exp"; //specify sprite index number for the expression
    public const string LEFT_CHARA_TAG = "Left"; //specify characterName
    public const string CENTER_CHARA_TAG = "Center"; //specify characterName
    public const string RIGHT_CHARA_TAG = "Right"; //specify characterName

    public const string LEFT_EXP_TAG = "LeftExp";
    public const string CENTER_EXP_TAG = "CenterExp";
    public const string RIGHT_EXP_TAG = "RightExp";


    // RGB Values for Rendering Characters
    public static Color NORMAL_COLOR = (Color)(new Color32(255, 255, 255, 255));
    public static Color IDLE_COLOR = (Color)(new Color32(150, 150, 150, 255));

    // Character Names
    public const string ANXIOUS_MC = "AnxiousChan";

    // Side Characters
    public const string HISTORY_TEACHER = "HistoryTeacher";
    public const string BLONDE_FRIEND = "BlondeFriend";

    // NPCs
    public const string BLOB_NPC = "NPC";
    public const string STUDENT_NPC = "StudentNPC";

    // None
    public const string NONE = "NONE";

}
