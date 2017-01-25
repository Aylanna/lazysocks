using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class GameMenu : MonoBehaviour {
	
	private GameController gc;
	public Text lifePointText;
	public Image img;
	public Image item1;
	public Image item2;
	public Image item3;
	public Image gameMessage;
	public Sprite extraDice;
	public Sprite extralife;
	public Sprite skip;
	public Sprite minigame;

	void Start () {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
		item1.enabled = false;
		item2.enabled = false;
		item3.enabled = false;
		gameMessage.enabled = false;
	}

	public void UpdateView() {
		lifePointText.text = gc.activePlayer.GetComponent<PlayerController> ().GetLifePoints().ToString();

		img.sprite = gc.activePlayer.GetComponentInChildren<SpriteRenderer> ().sprite;
	}

	public void SetFieldEventMessage(string message) {

	//	gameMessage.text = message;
	} 

	public void SetItemVisible(int index) {

		switch (index) {

		case 1:
			item1.enabled = true;
			break;
		case 2:
			item2.enabled = true;
			break;
		case 3:
			item3.enabled = true;
			break;
		}
	}

	public void DeactivateGameMessage() {
		gameMessage.enabled = false;
	}

	public void SwitchGameMessage(int index)  {
		gameMessage.enabled = true;
		switch (index) {
		case 1:
			
			gameMessage.sprite = extraDice;
			break;
		case 2:
			gameMessage.sprite = extralife;
			break;
		case 3:
			gameMessage.sprite = skip;
			break;

		case 4:
			gameMessage.sprite = minigame;
			break;
		}

	}

}
