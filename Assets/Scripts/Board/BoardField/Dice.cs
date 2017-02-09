using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * This class mamange to roll the dice on board.
 * 
 * @author Annkatrin Harms
 */
public class Dice : MonoBehaviour {

    public Sprite[] sprites = new Sprite[6];
    public Canvas rollADice;
    private Button dice;
    public Text messageText;
	public Button nextPlayer;
	public Text titleMessage;


    void Start() {
        dice = rollADice.GetComponent<Canvas>().GetComponentInChildren<Button>();
    }
   
	/**
	 * Each dice value has its own sprite.
	 * The value is chosen by random.
	 */
    public void RollDice() {
		if (!GameController.Instance.DeactivateDice) {
			GameController.Instance.DeactivateDice = true;
		int index = Random.Range (1, 7);
			dice.interactable = true;
			switch (index) {
			case 1:
				dice.image.sprite = sprites [0];
				break;
			case 2:
				dice.image.sprite = sprites [1];
				break;
			case 3:
				dice.image.sprite = sprites [2];
				break;
			case 4:
				dice.image.sprite = sprites [3];
				break;
			case 5:
				dice.image.sprite = sprites [4];
				break;
			case 6:
				dice.image.sprite = sprites [5];
				break;
			}
			if (nextPlayer.gameObject.activeSelf)
				SetDiceInActive ();
			GameController.Instance.IsDice = true;
			if (GameController.Instance.ActivePlayer != null)
				GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().DiceValue = index;
		}
    }

	/**
	 * Next player button for dice highscore
	 */
	public void SetNextPlayer() {
		if (!GameController.Instance.isEqualHighScore ()) {
			GameController.Instance.PlayerIDDice+=1;
		}
		SetStartDice ();
		SetDiceActive ();
		if (GameController.Instance.PlayerIDDice == GameController.Instance.NumbersOfPlayers) {
			SetDiceInActive ();
		}
	}

	/**
	 * Disable Next Player button 
	 */
	public void InActivateNextPlayer() {
		nextPlayer.gameObject.SetActive (false);
	}

	//Setter
	public void SetStartDice() {
		dice.image.sprite = sprites [0];
	}
	public void SetButtonActive() {
		nextPlayer.enabled = true;
	}

	public void SetButtonInActive() {
		nextPlayer.enabled = false;
	}

	public void SetDiceActive() {
		dice.enabled = true;
	}

	public void SetDiceInActive() {
		dice.enabled = false;
	}

	public void SetMessage(string message) {
		titleMessage.text = message;
	}
}
