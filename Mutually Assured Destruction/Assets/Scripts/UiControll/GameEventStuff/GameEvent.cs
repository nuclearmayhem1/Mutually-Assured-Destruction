using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Event", menuName = "GameAssets/Event", order = 1)]
public class GameEvent : ScriptableObject
{

    //Content
    [TextArea()]
    public string title;
    public string content;
    public Sprite image;

    //Conditions
    public EventCondition eventCondition;

    //Options
    [SerializeField]public GameEventOption[] eventOptions;



}