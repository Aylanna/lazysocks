using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour {

    private Canvas gameOverCanvas;
	public GameObject additiveScene;
	private Sceneloader scl;
	private bool extraLife;


    [SerializeField] private Text finalScore;
    [SerializeField] private Text neededScore;
    [SerializeField] private Text lives;

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
		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();
		scl.SetExtraLife (extraLife);
		scl.UnLoadMinigame ();
	    Destroy (additiveScene);



	}
}
