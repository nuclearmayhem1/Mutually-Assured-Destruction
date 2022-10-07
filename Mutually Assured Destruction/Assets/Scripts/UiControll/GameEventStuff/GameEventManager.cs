using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameEventManager : MonoBehaviour
{
    public GameEvent[] eventList;

    public GameObject popupPrefab;
    public GameObject buttonPrefab;
    public GameObject parentObject;


    private void Start()
    {
        TestEvent(eventList[0], GameManager.Instance.nations[0]);
    }



    public bool TestEvent(GameEvent gameEvent, Nation nation)
    {
        eventVariables vars = new eventVariables();
        vars.owner = nation;
        vars.opposingSide = new List<Nation>();
        vars.neutralSide = new List<Nation>();
        vars.ownerSide = new List<Nation>();

        if (TestCondition(gameEvent.eventCondition, ref vars))
        {
            GameObject popupObj = Instantiate(popupPrefab, parentObject.transform);
            Popup popup = popupObj.GetComponent<Popup>();
            popup.title.text = gameEvent.title;
            popup.image.sprite = gameEvent.image;

            foreach (GameEventOption option in gameEvent.eventOptions)
            {
                GameObject button = Instantiate(buttonPrefab, popup.buttonLayout.transform);
                button.GetComponentInChildren<Text>().text = option.title;

                button.GetComponent<Button>().onClick.AddListener(() => option.option.Invoke(vars, option.scale));
                button.GetComponent<Button>().onClick.AddListener(() => popup.DestroyThis());
            }

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
