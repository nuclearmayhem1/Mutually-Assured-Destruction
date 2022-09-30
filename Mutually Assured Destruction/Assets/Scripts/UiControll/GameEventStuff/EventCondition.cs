using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public delegate bool Condition(Nation nation);


[Serializable]
public class EventCondition
{
    public ConditionDropdown conditionName;
    [Tooltip("What operation is used to evaluate childconditions")]public Operation operation;
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