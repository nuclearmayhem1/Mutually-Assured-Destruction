using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplePopup : MonoBehaviour
{
    public Text title;
    public Image image;

    public void ClosePopup()
    {
        Destroy(gameObject);
    }

}
