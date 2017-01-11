using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;

public class UIManagerT : MonoBehaviour
{
	public Button[] buttons;
    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;

	public Text scoreText;
    public Text gameOverScoreText;
    public Text neededScoreText;
    public Text extraLifeText;

	private bool gameOver;
	private int score;
    private int neededScore = 30;

	// Use this for initialization
	void Start ()
	{
	    //set mainmenu panel as active from the start and set the time scale on 0
	    mainMenuPanel = GameObject.Find("MainMenuPanel");
	    Time.timeScale = 0;
	    mainMenuPanel.SetActive(true);

	    //set the game over panel as disabled from the start
	    gameOverPanel = GameObject.Find("GameOverPanel");
	    gameOverPanel.SetActive(false);

		gameOver = false;
		score = 0;
		//InvokeRepeating ("ScoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoreText.text = "Score: " + score + "\n" + "Goal: " + neededScore;
	}

	public void ScoreUpdate()
	{
		if (gameOver == false)
		{
			score += 1;
		}
	    if (score >= neededScore)
	    {
	        GameOver();
	    }
	}

	public void GameOver()
	{
		gameOver = true;
	    gameOverScoreText.text = "Your score: " + score;
	    neededScoreText.text = "Goal: " + neededScore;

	    if (score >= neededScore)
	    {
	        extraLifeText.text = "You got an extra life";
	    }
	    else
	    {
	        extraLifeText.text = "You didn't get an extra life";
	    }

		gameOverPanel.SetActive(true);
	    Pause();
	}

	public void Play()
	{
	    mainMenuPanel.SetActive(false);
	    Pause();
	}

	public void Pause()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
	}
	
	public void BackToBoard()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
