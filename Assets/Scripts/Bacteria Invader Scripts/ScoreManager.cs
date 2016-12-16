using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{

	public static int score = 0;
	private Text text;

	private void Start()
	{
		text = GetComponent<Text>();
		Reset();
	}
			
	public void Score(int points)
	{
		score += points;
		text.text = score.ToString();
	}
	
	public static void Reset()
	{
		score = 0;
	}
}
