using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ConditionList
{

    public static readonly Dictionary<string, Condition> conditions = new Dictionary<string, Condition>()
    {
        {"IsRelationsBad", IsRelationsBad},
        {"IsPoor", (Nation n) => n.wealth < 0.2f }
    };



    public static bool IsRelationsBad(Nation nation)
    {
        List<float> relations = nation.relations;

        for (int i = 0; i < relations.Count; i++)
        {
            if (relations[i] < -0.5f)
            {
                if (GameManager.Instance.nations[i].relations[nation.ID] < -0.5f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool IsPoor(Nation nation)
    {
        if (nation.wealth < 0.2f)
        {
            return true;
        }
        return false;
    }

}
