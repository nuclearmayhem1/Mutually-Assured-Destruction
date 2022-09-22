using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Popup : MonoBehaviour
{
    public Text title, content;
    public Image image;
    public GameObject buttonLayout;

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
