using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This class mamange the start story menu of the game.
 * 
 * @author Annkatrin Harms
 */
public class Story : MonoBehaviour {

	public Canvas story;
	public Sprite[] stories;
	public Sprite story1;
	public Sprite story2;
	public Sprite story3;
	public Sprite story4;
	public Sprite story5;
	public Sprite info;
	private int clickIndex = 0;
	private GameController gc;

	void Start() {
		stories = new Sprite[6];
		stories [0] = story1;
		stories [1] = story2;
		stories [2] = story3;
		stories [3] = story4;
		stories [4] = story5;
		stories [5] = info;
	}
		
	public void NextStory() {
		if (clickIndex < stories.Length) {
			story.GetComponentInChildren<Image> ().sprite = stories [clickIndex];
			clickIndex++;
		} else {
			story.enabled = false;
			GameController.Instance.State = 1;
		}
	}
	

}
