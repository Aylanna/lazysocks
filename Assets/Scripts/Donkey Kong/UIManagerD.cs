using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerD : MonoBehaviour
{
	public Button[] buttons;
	public GameObject mainMenuPanel;
	public GameObject gameOverPanel;

	public Text gameOverText;

	private bool gameOver;

	public GameObject additiveScene;
	private Sceneloader scl;
	private bool loseLifePoint;
	private bool item;


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

	public void GameOverBossDefeat()
	{
		gameOver = true;
		gameOverText.text = "Good Job You defeated the boss!" + '\n' + " You got the magic toilet brush!";
		item = true;
		gameOverPanel.SetActive(true);
	}

	public void GameOverNoBossDefeat()
	{
		gameOver = true;
		gameOverText.text = "You didnt defeat the boss";
		loseLifePoint = true;
		gameOverPanel.SetActive(true);
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
		Destroy (additiveScene);
	}
}
