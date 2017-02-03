using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerM : MonoBehaviour
{
	public Button[] buttons;
    public GameObject storyStartPanel;
    public GameObject mainMenuPanel;
    public GameObject storyEndPanel;
    public GameObject gameOverPanel;

    public GameObject additiveScene;
	private Sceneloader scl;
	private bool lifePoint;
	private bool item;
	public Text gameOverText;

	private bool gameOver;


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
	}

	public void GameOverBossDefeat()
	{
        Pause();
		gameOver = true;
		gameOverText.text = "You mached every card and defeated the Boss!";
		item = true;
        //gameOverPanel.SetActive (true); 
        storyEndPanel.SetActive(true);
    }

	public void GameOverNoBossDefeat()
	{
        Pause();
		gameOver = true;
		gameOverText.text = "You didnt defeat the boss and have no lives anymore :(";
		lifePoint = true;
		gameOverPanel.SetActive(true);
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
		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();
		scl.SetLoseLifePoint (lifePoint);
		scl.SetItem (item);
		scl.SetPlayedBossBattle (true);
		scl.UnLoadMinigame ();
		Destroy (additiveScene);
	}
}
