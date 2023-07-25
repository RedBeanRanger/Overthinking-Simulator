using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Bar Controller SO", menuName = "ScriptableObjects/Bar Controller SO")]
public class BarController : ScriptableObject
{
    public int MaxBarValue = 100;
    public int MinBarValue = 0;

    // *****Public fields*****//
    public int SBarValue; //social
    public int HBarValue; //happiness
    public int PBarValue; //personal
    public int ABarValue; //anxiety



    //*****Unity Events*****//
    public UnityEvent<string, int> BarValueChangeEvent;

    /*
    public UnityEvent<int> SChangeEvent;
    public UnityEvent<int> HChangeEvent;
    public UnityEvent<int> PChangeEvent;
    public UnityEvent<int> AChangeEvent;
    */

    // ***** Unity Object Functions *****
    // Executed whenever the object with this script is enabled.
    void OnEnable()
    {
        SBarValue = 16;
        HBarValue = 16;
        PBarValue = 16;
        ABarValue = 20;

        if (BarValueChangeEvent == null)
        {
            BarValueChangeEvent = new UnityEvent<string, int>();
        }
    }


    //***** public functions *****
    // change bar value, given name of the bar (string) and amount (int)
    public void ChangeBarValue(string barName, int amount)
    {
        switch (barName)
        {
            case "SBar":
                ChangeSBarValue(amount);
                setBarValueWithinBounds(barName);
                BarValueChangeEvent.Invoke(barName, SBarValue); //invoke the event with the name of the bar and the new bar value
                break;
            case "HBar":
                ChangeHBarValue(amount);
                setBarValueWithinBounds(barName);
                BarValueChangeEvent.Invoke(barName, HBarValue);
                break;
            case "PBar":
                ChangePBarValue(amount);
                setBarValueWithinBounds(barName);
                BarValueChangeEvent.Invoke(barName, PBarValue);
                break;
            case "ABar":
                ChangeABarValue(amount);
                setBarValueWithinBounds(barName);
                BarValueChangeEvent.Invoke(barName, ABarValue);
                break;
            default:
                Debug.LogWarning("Bar value not changed: " + barName + ", check if you have the correct barName.");
                break;
        }
    }


    // change social bar value
    public void ChangeSBarValue(int amount)
    {
        SBarValue += amount;
        //SChangeEvent.Invoke(amount);
    }

    // change happiness bar value
    public void ChangeHBarValue(int amount)
    {
        HBarValue += amount;
        //HChangeEvent.Invoke(amount);
    }

    // change personal bar value
    public void ChangePBarValue(int amount)
    {
        PBarValue += amount;
        //PChangeEvent.Invoke(amount);
    }

    // change anxiety bar value
    public void ChangeABarValue(int amount)
    {
        ABarValue += amount;
        //AChangeEvent.Invoke(amount);
    }



    //***** private functions *****//
    // Make sure the given barName bar does not exceed MaxBarValue or MinBarValue. If it does, set it to the corresponding bound the value was exceeding

    private void setBarValueWithinBounds(string barName)
    {
        switch (barName){
            case "SBar":
                if (SBarValue > MaxBarValue)
                {
                    SBarValue = MaxBarValue;
                }
                if (SBarValue < MinBarValue)
                {
                    SBarValue = MinBarValue;
                }
                break;
            case "HBar":
                if (HBarValue > MaxBarValue)
                {
                    HBarValue = MaxBarValue;
                }
                if (HBarValue < MinBarValue)
                {
                    HBarValue = MinBarValue;
                }
                break;
            case "PBar":
                if (PBarValue > MaxBarValue)
                {
                    PBarValue = MaxBarValue;
                }
                if (PBarValue < MinBarValue)
                {
                    PBarValue = MinBarValue;
                }
                break;
            case "ABar":
                if (ABarValue > MaxBarValue)
                {
                    ABarValue = MaxBarValue;
                }
                if (ABarValue < MinBarValue)
                {
                    ABarValue = MinBarValue;
                }
                break;
        }
    }

}
