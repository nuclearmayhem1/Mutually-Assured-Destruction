using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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


    //Game variables
    public float time = 0;
    public float nuclearRisk = 0;


    //Timing
    public float days = 0;
    public Action onNewDay;
    public float gameSpeed = 0;

    public bool forcePaused = false;

    private float lastDay = 0;
    private void Update()
    {
        if (!forcePaused)
        {
            days += gameSpeed * Time.deltaTime;
        }

        if (days > lastDay + 1)
        {
            lastDay = days;
            onNewDay.Invoke();
        }

    }
}
