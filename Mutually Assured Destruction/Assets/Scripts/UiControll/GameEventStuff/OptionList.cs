using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OptionList
{

    public static readonly Dictionary<string, EventOption> options = new Dictionary<string, EventOption>()
    {
        {"exampleMethod", exampleMethod},
        {"logScale", (v, s) => { Debug.Log(s); } }
    };

    public static void exampleMethod(eventVariables vars, float scale)
    {
        Debug.Log(vars.opposingSide[0].name);
    }

}
