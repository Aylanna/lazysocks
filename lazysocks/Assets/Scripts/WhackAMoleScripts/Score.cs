using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score;
    public static int highScore;
    public Text txtScore;

    // Use this for initialization
    void Start ()
    {
        txtScore = gameObject.GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("High Score");
    }

    // Update is called once per frame
    void Update ()
    {
        txtScore.text = "Score: " + score.ToString() + "                                               High Score: " + highScore.ToString();

        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);
        }
    }
}
