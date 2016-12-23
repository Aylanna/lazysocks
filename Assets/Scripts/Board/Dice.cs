using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    public Sprite[] sprites = new Sprite[6];
    public Canvas rollADice;
    private Button dice;
    private GameController controller;
    public Text messageText;
	public Button nextPlayer;
	public Text titleMessage;


    void Start()
    {
        dice = rollADice.GetComponent<Canvas>().GetComponentInChildren<Button>();
        
        if(controller == null)
        {
            controller = GetComponent<GameController>();
        }
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
   
    public void RollDice()
    {
        int index = Random.Range(1, 7);
        dice.interactable = true;
        switch(index)
        {
            case 1:
                dice.image.sprite = sprites[0];
                break;
            case 2:
                dice.image.sprite = sprites[1];
                break;
            case 3:
                dice.image.sprite = sprites[2];
                break;
            case 4:
                dice.image.sprite = sprites[3];
                break;
            case 5:
                dice.image.sprite = sprites[4];
                break;
            case 6:
                dice.image.sprite = sprites[5];
                break;
        }
		if(nextPlayer.gameObject.activeSelf)
			SetDiceInActive ();
		controller.isDice = true;
		if(controller.activePlayer != null)
        	controller.activePlayer.GetComponent<PlayerController>().SetDiceValue(index);
    }

	public void SetNextPlayer() {
	   controller.playerIDDice++;
		SetDiceActive ();
		if (controller.playerIDDice == controller.numbersOfPlayers) {
			SetDiceInActive ();

		}

	}

	public void InActivateNextPlayer() {
		nextPlayer.gameObject.SetActive (false);

	}
}
