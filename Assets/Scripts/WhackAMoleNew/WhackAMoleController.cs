using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class WhackAMoleController : MonoBehaviour {

	private int timerSeconds = 30;
	private SpawnCharacters spawner;
	private InputController ic;

    public Canvas startCanvas;
	public Canvas gameOverCanvas;
    public Canvas storyStartCanvas;
    public Canvas storyEndCanvas; 

	public GameObject additiveScene;
	private Sceneloader scl;
	private bool extraLife;
	public Text extraLifeText; 
	public Text scoreText;


	void Start () {
		
		spawner = GetComponent<SpawnCharacters> ();
		ic = GetComponent<InputController> ();
		gameOverCanvas.enabled = false;
        startCanvas.enabled = false;
        storyEndCanvas.enabled = false; 
	}

	void Update() {

		scoreText.text = "Score = " + ic.score; 

		if (ic.gameOver) {
			gameOverCanvas.enabled = true;
			extraLifeText.text = "You were catched by the tentacle! No extra life for you..."; 
			CancelInvoke ("CountDown");
			spawner.StopSpawn ();
			ic.gameOver = false;
		}
		if (ic.score == 1) {
            storyEndCanvas.enabled = true;
            CancelInvoke("CountDown");
            spawner.StopSpawn();
            extraLife = true;
            ic.gameOver = false;

        }
	}

	void CountDown() {
		
		timerSeconds--;
		if (timerSeconds < 1) {
			CancelInvoke ("CountDown");
			spawner.StopSpawn ();
		}
	}

	public void StartGame() {
		
		InvokeRepeating ("Countdown", 1, 1);
		spawner.StartSpawnInterval ();
		startCanvas.enabled = false;
	}

    public void StartStory()
    {
        storyStartCanvas.enabled = false;
        startCanvas.enabled = true; 
    }

	public void BackToBoard() {
		
		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();
		scl.SetExtraLife (extraLife);
		scl.UnLoadMinigame ();
		Destroy (additiveScene);
	}
}
