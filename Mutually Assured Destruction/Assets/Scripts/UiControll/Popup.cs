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

    private void Awake()
    {
        GameManager.Instance.forcePaused = true;
    }

    public void DestroyThis()
    {
        GameManager.Instance.forcePaused = false;
        Destroy(gameObject);
    }
}
