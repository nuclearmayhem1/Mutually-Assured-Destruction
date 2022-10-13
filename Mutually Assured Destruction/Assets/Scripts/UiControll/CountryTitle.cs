using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CountryTitle : MonoBehaviour, IPointerClickHandler
{
    public Nation nation;

    public void OnPointerClick(PointerEventData eventData)
    {

        if (Player.Instance.nation.ID == -1)
        {
            Player.Instance.nation = nation;
        }
    }

}
