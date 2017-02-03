using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endstory : MonoBehaviour {

	public Canvas endStory;

	public Sprite[] stories;
	public Sprite endStory1;
	public Sprite endStory2;
	public Sprite endStory3;
	public Sprite endStory4;
	public Image winner;

	private int clickIndex = 0;
	private GameController gc;

	void Start() {
		winner.enabled = false;
		endStory.enabled = false;
		stories = new Sprite[5];
		stories [0] = endStory1;
		stories [1] = endStory2;
		stories [2] = endStory3;
		stories [3] = endStory4;

	}
		
	public void NextStory() {
		if (clickIndex < stories.Length) {
			endStory.GetComponentInChildren<Image> ().sprite = stories [clickIndex];
			if (clickIndex == stories.Length - 1) {
				winner.sprite = GameController.Instance.ActivePlayer.GetComponentInChildren<SpriteRenderer> ().sprite;
				winner.enabled = true;
			}
			clickIndex++;
		} else {
			GameController.Instance.State = 12;
		}
	}
}
