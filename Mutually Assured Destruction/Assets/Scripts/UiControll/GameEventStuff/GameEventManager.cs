using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public GameEvent[] eventList;



    private void Start()
    {
        TestEvent(eventList[0], GameManager.Instance.nations[0]);
    }



    public bool TestEvent(GameEvent gameEvent, Nation nation)
    {
        eventVariables vars = new eventVariables();


        if (TestCondition(gameEvent.eventCondition, ref vars))
        {
            gameEvent.eventOptions[0].option.Invoke(vars, gameEvent.eventOptions[0].scale);
            return true;
        }

        return false;
    }


    public bool TestCondition(EventCondition condition, ref eventVariables vars)
    {
        if (!condition.condition.Invoke(ref vars, condition.scale))
        {
            return false;
        }
        else if (condition.childConditions.Count == 0)
        {
            return true;
        }
        else if (condition.childConditions.Count > 0)
        {
            bool[] results = new bool[condition.childConditions.Count];
            for (int i = 0; i < condition.childConditions.Count; i++)
            {
                results[i] = TestCondition(condition.childConditions[i], ref vars);
            }

            switch (condition.operation)
            {
                case Operation.ALL:
                    foreach (bool b in results)
                    {
                        if (!b)
                        {
                            return false;
                        }
                    }
                    return true;

                case Operation.ANY:
                    foreach (bool b in results)
                    {
                        if (b)
                        {
                            return true;
                        }
                    }
                    return false;

                case Operation.NOTALL:
                    foreach (bool b in results)
                    {
                        if (!b)
                        {
                            return true;
                        }
                    }
                    return false;

                case Operation.NONE:
                    foreach (bool b in results)
                    {
                        if (b)
                        {
                            return false;
                        }
                    }
                    return true;

                case Operation.SOME:
                    bool anyTrues = false;
                    foreach (bool b in results)
                    {
                        if (b)
                        {
                            anyTrues = true;
                        }
                        else if (!b && anyTrues)
                        {
                            return true;
                        }
                    }
                    return false;

                default:
                    return false;
            }
        }
        return false;
    }


}
