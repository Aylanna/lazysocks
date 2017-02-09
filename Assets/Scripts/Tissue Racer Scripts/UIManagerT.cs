using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerT : MonoBehaviour
{
	public Button[] buttons;
    public GameObject storyStartPanel;
    public GameObject mainMenuPanel;
    public GameObject storyEndPanel;
    public GameObject gameOverPanel;

    public Text scoreText;
    public Text gameOverScoreText;
    public Text neededScoreText;
    public Text extraLifeText;

	private bool gameOver;
	private int score;
    private int neededScore = 30;

	private bool extralife;
	public GameObject additiveScene;
	private Sceneloader scl;

	// Use this for initialization
	void Start ()
	{
        //set story panel as active from the start and set time scal to 0
        storyStartPanel = GameObject.Find("StoryStartPanel");
        Time.timeScale = 0;
        storyStartPanel.SetActive(true);
        //set mainmenu panel as disabled from the start
        mainMenuPanel = GameObject.Find("MainMenuPanel");
        mainMenuPanel.SetActive(false);
        //set the story end panel as disabled from the start
        storyEndPanel = GameObject.Find("StoryEndPanel");
        storyEndPanel.SetActive(false);
        //set the game over panel as disabled from the start
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);

        gameOver = false;
		score = 0;

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
        Pause(); 
	    gameOverScoreText.text = "Your score: " + score;
	    neededScoreText.text = "Goal: " + neededScore;

	    if (score >= neededScore)
	    {
	        extraLifeText.text = "You got an extra life";
			extralife = true;
            storyEndPanel.SetActive(true);

        }
	    else
	    {
	        extraLifeText.text = "You didn't get an extra life";
            gameOverPanel.SetActive(true);
        } 
	}

	public void Play()
	{
	    mainMenuPanel.SetActive(false);
	    Pause();
	}

    public void StoryStart()
    {
        storyStartPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void StoryEnd()
    {
        storyEndPanel.SetActive(false);
        gameOverPanel.SetActive(true);
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
        
		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();
		scl.SetExtraLife (extralife);
		scl.UnLoadMinigame ();
        Time.timeScale = 1;
		Destroy (additiveScene);
		//Application.LoadLevel(Application.loadedLevel);
	}



}
