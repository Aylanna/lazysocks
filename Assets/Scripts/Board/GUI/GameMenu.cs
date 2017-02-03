using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * This class mamange the game menu for the game.
 * 
 * @author Annkatrin Harms
 */
public class GameMenu : MonoBehaviour {
	
	private GameController gc;
	public Text lifePointText;
	public GameObject boardBackground;

	public Image img;
	public Image item1;
	public Image item2;
	public Image item3;
	public Image gameMessage;

	public Sprite extraDice;
	public Sprite extralife;
	public Sprite skip;
	public Sprite minigame;
	public Sprite gameOver;
	public Sprite moveForward;
	public Sprite moveBackward;
	public Sprite sickFLower;
	public Sprite healedLeafSection1s;
	public Sprite healedLeafSection2s;
	public Sprite healedLeafSection3s;

	void Start () {
		//gc = GameObject.Find("GameController").GetComponent<GameController> ();
		DisableItems ();
		gameMessage.enabled = false;
	}

	/**
	 * Disable the player items from the player
	 */
	public void DisableItems() {
		item1.enabled = false;
		item2.enabled = false;
		item3.enabled = false;
	}

	/**
	 * Updates the game menu for the active player. Like lifes, items and the background from the board.
	 */
	public void UpdateView() {
		lifePointText.text = GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().LifePoints.ToString();
		SetItemVisible (GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().Items);
		img.sprite = GameController.Instance.ActivePlayer.GetComponentInChildren<SpriteRenderer> ().sprite;
		CheckBoardBackground ();
	}

	/**
	 * Manages which background needs to be activated for the active player.
	 */
	public void CheckBoardBackground() {
		if (!GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection1 () &&
		   !GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection2 () &&
		   !GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection3 ()) {
			boardBackground.GetComponentInChildren<SpriteRenderer> ().sprite = sickFLower;
		}

		if (GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection1 () &&
			!GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection2() &&
		   !GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection3 ()) {
			boardBackground.GetComponentInChildren<SpriteRenderer> ().sprite = healedLeafSection1s;
		}
		if (!GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection1 () &&
		   GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection2 () &&
		   !GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection3 ()) {
			boardBackground.GetComponentInChildren<SpriteRenderer> ().sprite = healedLeafSection2s;
		}
		if (!GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection1 () &&
		   !GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection2 () &&
		   GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsHealedLeafSection3 ()) {
			boardBackground.GetComponentInChildren<SpriteRenderer> ().sprite = healedLeafSection3s;
		}
	}

	/**
	 * Manages which item need to be activated for the active player.
	 */
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

	/**
	 * Disable the game message on board.
	 */
	public void DeactivateGameMessage() {
		gameMessage.enabled = false;
	}

	/**
	 * Switch the game message on board
	 */
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
		case 5:
			gameMessage.sprite = moveForward;
			break;
		case 6:
			gameMessage.sprite = moveBackward;
			break;
		case 7:
			gameMessage.sprite = gameOver;
			break;
		}
	}
}
