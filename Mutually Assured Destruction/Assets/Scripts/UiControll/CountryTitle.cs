using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CountryTitle : MonoBehaviour, IPointerClickHandler
{
    public int nationID = -1;


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (Player.Instance.nationID == -1)
        {
            Player.Instance.nationID = nationID;
        }
    }
}
