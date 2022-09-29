using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public struct GameEvent
{

    //Content
    public string title;
    public string content;
    public Sprite image;

    //Conditions

    List<int> s;

    void eee()
    {
        s.Find(i => i>1);
    }

    //Options




}