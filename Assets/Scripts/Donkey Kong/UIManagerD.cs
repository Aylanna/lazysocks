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
	private bool extraLife;


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
		gameOverText.text = "You got the magic toilet brush! Thus defeated the boss and got the item.";

		gameOverPanel.SetActive(true);
		Pause();
	}

	public void GameOverNoBossDefeat()
	{
		gameOver = true;
		gameOverText.text = "You didnt defeat the boss";

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
		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();
		scl.SetExtraLife (extraLife);
		scl.UnLoadMinigame ();
		Destroy (additiveScene);
	}
}
