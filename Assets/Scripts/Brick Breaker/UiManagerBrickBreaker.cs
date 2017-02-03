using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManagerBrickBreaker : MonoBehaviour {

	public Button[] buttons;
    public GameObject storyStartPanel; 
	public GameObject mainMenuPanel;
    public GameObject storyEndPanel; 
	public GameObject gameOverPanel;
	private DestroyBrickBreaker scene;

	public Text scoreText;
	public Text gameOverScoreText;
	public Text extraLifeText;

	private bool gameOver;
	private int score;
	private int neededScore = 20;

	public Sceneloader scl;
	public bool extraLife;


	// Use this for initialization
	void Start () {
        //set story panel as active from the start and set time scal to 0
        storyStartPanel = GameObject.Find("StoryStartPanel");
        Time.timeScale = 0;
        storyStartPanel.SetActive(true); 
        //set mainmenu panel as disabled from the start
        mainMenuPanel = GameObject.Find("MainMenuPanel");
		mainMenuPanel.SetActive(false);
		scene = GameObject.Find("BrickBreaker").GetComponent<DestroyBrickBreaker> ();
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
	void Update () {
	}

	public void IncrementScore(){
		score++;
		scoreText.text = "Score: " + score;

		if (score == neededScore) {
			GameOver (); 
		}
	}

	public void GameOver()
	{
		gameOver = true;
        Pause();
		gameOverScoreText.text = "Your score: " + score;

		if (score >= neededScore)
		{
			extraLifeText.text = "You got an extra life";
			extraLife = true;
		}
		else
		{
			extraLifeText.text = "You didn't get an extra life";
		}

        storyEndPanel.SetActive(true); 
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
        Pause();
		//scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();
		//gameObject.SendMessage ("WashMe", 0, SendMessageOptions.DontRequireReceiver);
		scene.DestroyScene ();

	}

}