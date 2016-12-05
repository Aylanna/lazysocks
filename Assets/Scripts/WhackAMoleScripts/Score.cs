using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score;
    public static int neededScoreForLive;
    public Text txtScore;

    // Use this for initialization
    void Start ()
    {
        txtScore = gameObject.GetComponent<Text>();
        neededScoreForLive = 3;
    }

    // Update is called once per frame
    void Update ()
    {
        txtScore.text = "Score: " + score + "                                               Needed Score: " + neededScoreForLive;
    }
}
