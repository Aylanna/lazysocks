using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private float timer;

    [SerializeField] private Canvas countDownCanvas;
    [SerializeField] private Text countDown;

    void Start()
    {
        countDownCanvas = GetComponent<Canvas>();
    }

	// Update is called once per frame
	void Update ()
	{
	    timer = Spawner.timeLeft;
	    timer -= Time.deltaTime;
	    countDown.text = Math.Round(timer).ToString();

	    if (timer <= 0)
	    {
	        countDown.enabled = false;
	        countDownCanvas.enabled = false;
	    }
	}
}
