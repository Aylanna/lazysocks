using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour {

    private Canvas gameOverCanvas;

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
            TimeOut.wrongCharacter = false;
            Spawner.spawnNum = 1;
        }
        else
        {
            lives.text = "You didn't get an extra live";
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
}
