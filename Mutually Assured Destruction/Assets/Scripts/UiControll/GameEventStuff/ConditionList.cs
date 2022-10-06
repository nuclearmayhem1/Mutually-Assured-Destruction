using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ConditionList
{

    public static readonly Dictionary<string, Condition> conditions = new Dictionary<string, Condition>()
    {
        {"AlwaysTrue", (ref eventVariables v, float s) => {return true; } },
        {"AlwaysFalse", (ref eventVariables v, float s) => {return true; } },
        {"Relations>Scale", (ref eventVariables v, float s) => RelationsHigherThan(ref v,s)},
        {"Relations<Scale", (ref eventVariables v, float s) => RelationsLowerThan(ref v,s)},
        {"AllRivals", (ref eventVariables v, float s) => AllRivals(ref v,s)},
        {"RandomRival", (ref eventVariables v, float s) => RandomRival(ref v,s)},
    };



    public static bool RelationsHigherThan(ref eventVariables vars, float scale)
    {
        List<float> relations = vars.owner.relations;

        for (int i = 0; i < relations.Count; i++)
        {
            if (relations[i] < -0.5f)
            {
                if (GameManager.Instance.nations[i].relations[vars.owner.ID] > scale)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool RelationsLowerThan(ref eventVariables vars, float scale)
    {
        List<float> relations = vars.owner.relations;

        for (int i = 0; i < relations.Count; i++)
        {
            if (relations[i] < -0.5f)
            {
                if (GameManager.Instance.nations[i].relations[vars.owner.ID] < scale)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool AllRivals(ref eventVariables vars, float scale)
    {
        if (vars.owner.rivals.Count > 0)
        {
            foreach (Nation nation in vars.owner.rivals)
            {
                vars.opposingSide.Add(nation);
            }
            return true;
        }
        return false;
    }

    public static bool RandomRival(ref eventVariables vars, float scale)
    {
        if (vars.owner.rivals.Count > 0)
        {

            vars.opposingSide.Add(vars.owner.rivals[Random.Range(0, vars.owner.rivals.Count)]);
            return true;
        }
        return false;
    }
}
