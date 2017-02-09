﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBrickBreaker : MonoBehaviour
{

    public UiManagerBrickBreaker ui;
    public float timeLeft = 90;
    public Text timerText;

    // Use this for initialization
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Time Left: " + Mathf.Round(timeLeft);

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        ui.GameOver();
    }
}
