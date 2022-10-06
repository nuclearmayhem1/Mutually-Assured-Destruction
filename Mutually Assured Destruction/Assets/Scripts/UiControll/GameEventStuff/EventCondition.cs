using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public delegate bool Condition(ref eventVariables vars, float scale);


[Serializable]
public class EventCondition
{
    public ConditionDropdown conditionName;
    public float scale = 1;
    [Tooltip("What operation is used to evaluate childconditions")]
    public Operation operation;

    public Condition condition { get { return ConditionList.conditions[conditionName.conditionName]; } }
    [SerializeField] public List<EventCondition> childConditions = new List<EventCondition>();

}

public enum Operation
{
    ALL,
    ANY,
    NOTALL,
    NONE,
    SOME
}

public struct eventVariables
{
    public Nation owner;

    public List<Nation> ownerSide;
    public List<Nation> neutralSide;
    public List<Nation> opposingSide;
}