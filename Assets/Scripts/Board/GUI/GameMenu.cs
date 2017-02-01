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
	public GameObject boardBackground;
	public Sprite sickFLower;
	public Sprite healedLeafSection1;
	public Sprite healedLeafSection2;
	public Sprite healedLeafSection3;

	void Start () {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
		DisableItems ();
		gameMessage.enabled = false;
	}

	public void DisableItems() {
		item1.enabled = false;
		item2.enabled = false;
		item3.enabled = false;

	}

	public void UpdateView() {
		lifePointText.text = gc.activePlayer.GetComponent<PlayerController> ().GetLifePoints().ToString();
		SetItemVisible (gc.activePlayer.GetComponent<PlayerController> ().GetItem ());
		img.sprite = gc.activePlayer.GetComponentInChildren<SpriteRenderer> ().sprite;
		CheckBoardBackground ();
	}

	public void CheckBoardBackground() {
		if(gc.activePlayer.GetComponent<PlayerController> ().IsHealedLeafSection1())
			boardBackground.GetComponentInChildren<SpriteRenderer> ().sprite = healedLeafSection1;
		if(gc.activePlayer.GetComponent<PlayerController> ().IsHealedLeafSection2())
			boardBackground.GetComponentInChildren<SpriteRenderer> ().sprite = healedLeafSection2;
		if(gc.activePlayer.GetComponent<PlayerController> ().IsHealedLeafSection3())
			boardBackground.GetComponentInChildren<SpriteRenderer> ().sprite = healedLeafSection3;
	}
	public void SetFieldEventMessage(string message) {

	//	gameMessage.text = message;
	} 

	public void SetItemVisible(int index) {

		switch (index) {

		case 0: 
			item1.enabled = false;
			item2.enabled = false;
			item3.enabled = false;
			break;
		case 1:
			item1.enabled = true;
			item2.enabled = false;
			item3.enabled = false;
			break;
		case 2:
			item1.enabled = true;
			item2.enabled = true;
			item3.enabled = false;
			break;
		case 3:
			item1.enabled = true;
			item2.enabled = true;
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
