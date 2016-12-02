using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreResult : MonoBehaviour {

    public Text txt;

    // Use this for initialization
    void Start ()
    {
        txt = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update ()
    {
        txt.text = "Score: " + Score.score.ToString() + "\n" + "High Score: " + Score.highScore.ToString();
    }
}
