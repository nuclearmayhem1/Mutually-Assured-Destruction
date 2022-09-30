using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventOption();

[System.Serializable]
public class GameEventOption
{
    public string title;
    public string tooltip;
    public EventOption option;

}