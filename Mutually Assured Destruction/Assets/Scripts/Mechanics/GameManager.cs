using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public List<Nation> nations = new List<Nation>();

    private void Reset()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

}
