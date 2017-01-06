using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour {

    private Canvas gameOverCanvas;
	public GameObject additiveScene;
	private Sceneloader scl;
	private bool extraLife;


	public Text finalScore;
    public Text neededScore;
    public Text lives;

    // Use this for initialization
    void Start ()
    {
        gameOverCanvas = GetComponent<Canvas>();
        gameOverCanvas.enabled = false;


	
    }

    // Update is called once per frame
    void Update () {

        finalScore.text = "Final score: " + Score.score;
        neededScore.text = "Needed score for a life: " + Score.neededScoreForLive;

        if (!Spawner.isTapped)
        {
            StartCoroutine(PauseBeforeGameOver());

        }

        if (Spawner.playName == "Bad")
        {
            StartCoroutine(PauseBeforeGameOver());

        }

        if (Score.score == Score.neededScoreForLive)
        {
            StartCoroutine(PauseBeforeGameOver());
            lives.text = "You got an extra live";
			extraLife = true;
            TimeOut.wrongCharacter = false;
            Spawner.spawnNum = 1;
        }
        else
        {
            lives.text = "You didn't get an extra live";
			extraLife = false;
        }

    }
    /**
     * Pause the game before switching to the game over scene
     */
    protected IEnumerator PauseBeforeGameOver()
    {
        yield return new WaitForSeconds(1.0f);
        gameOverCanvas.enabled = true;
    }

	public void BackToBoard() {
		
		Spawner.check = false;
		Spawner.isTapped = true;
		Spawner.playName = "";
		Spawner.removeTimer = 0;
		Spawner.spawnNum = 0;
		Spawner.timeLeft = 0;
		Spawner.timer = 0;

	    Score.neededScoreForLive = 3;
		Score.score = 0;

		TimeOut.wrongCharacter = false;


		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();
		scl.SetExtraLife (extraLife);
		scl.UnLoadMinigame ();
	    Destroy (additiveScene);




	}
}
