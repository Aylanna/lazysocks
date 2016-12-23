using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour 
{

	// Use this for initialization
	private void Start ()
	{
		Text scoreText = GetComponent<Text>();
		scoreText.text = ScoreManager.score.ToString ();
		ScoreManager.Reset();
	}
}
