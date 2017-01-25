using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public Button[] buttons;
	public GameObject mainMenuPanel;
	public GameObject gameOverPanel;

	public Text bossDead; 

	private int score;  
	private bool gameOver;

	private Sceneloader scl;
	public bool loseLifePoint;
	public bool item;
	public GameObject additiveScene;

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
	}

	public void GameOverBossDefeated() 
	{
		gameOver = true; 
		bossDead.text = "Goodjob, You defeated the boss and got an item!";
		item = true;
		gameOverPanel.SetActive (true); 
		Pause ();
	}

	public void GameOver()
	{
		bossDead.text = "You didn't defeat the boss";
		loseLifePoint = true; 
		gameOver = true;
		gameOverPanel.SetActive(true);
		Pause ();
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
		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();
		scl.SetLoseLifePoint (loseLifePoint); 
		scl.SetItem (item);
		scl.UnLoadMinigame ();
		Pause ();
		Destroy (additiveScene);
	}
}
