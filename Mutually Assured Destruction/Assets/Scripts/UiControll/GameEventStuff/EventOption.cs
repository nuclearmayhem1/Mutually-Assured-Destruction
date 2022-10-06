using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void EventOption(eventVariables vars, float scale);

[System.Serializable]
public class GameEventOption
{
    public string title;
    public string tooltip;
    public OptionDropdown optionName;
    public float scale = 1;
    public EventOption option { get { return OptionList.options[optionName.optionName]; } }

    [SerializeField]
    public decisionMultipliers multipliers;
}

[System.Serializable]
public struct decisionMultipliers
{
    public int territoryAreaM;
    public float wealthM;
    public float populationM;
    public float powerM;
    public float trustM;

    public float aggresivenessM;
    public float stabilityM;
    public float securityM;
    public float peopleM;
    public float greedM;
}