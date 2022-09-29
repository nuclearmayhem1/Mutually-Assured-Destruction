using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[System.Serializable]
public class GameEvent
{

    //Content
    public string title;
    public string content;
    public Sprite image;

    //Conditions
    List<Predicate<Nation>> conditions;



    //Options




}

[Serializable]
public delegate bool Condition(Nation nation);


[Serializable]
public class EventCondition
{
    public Operation operation;
    [SerializeField] public Condition condition;
    [SerializeField] public List<EventCondition> childConditions = new List<EventCondition>();
}

public enum Operation
{
    AND,
    OR,
    NAND,
    NOR
}