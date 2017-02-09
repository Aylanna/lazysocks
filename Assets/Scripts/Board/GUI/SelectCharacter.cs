using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * This class mamange the selection of character menu for the game.
 * 
 * @author Annkatrin Harms
 */
public class SelectCharacter : MonoBehaviour {

    public Canvas selectCharacter;
	public Canvas story;
    public Text messageText;
    public Canvas rollADice;
    private int counter = 1;
    private GameController controller;
	private Toggle activeToggle;
	private bool isCharacterChoose;
    private Toggle[] characters;

    void Start() {
        characters = selectCharacter.GetComponent<Canvas>().GetComponentsInChildren<Toggle>();
        rollADice.GetComponent<Canvas>().enabled = false;
        SetToggleNotActive();
    }
		
	/**
	 * Deactivate all Toggle at the start of the game.
	 */
    void SetToggleNotActive() {
        foreach (Toggle t in characters){
            t.isOn = false;
        }
    }

	/**
	 * Manages the selection of each Toggle. 
	 */
    void IsCharacterToggleActive() {
        for (int i = 0; i < characters.Length; i++) {
            if (characters[i].isOn) {
				GameController.Instance.players[i].SetActive(true);
				characters [i].enabled = false;  
				characters [i].gameObject.SetActive (false);
				isCharacterChoose = true;
            }
        }
    }

	/*
	 * Sets chosen player active.
	 */
	void SetActivePlayers() {
		int index = 0;
		for (int i = 0; i < GameController.Instance.players.Count; i++) {
			if (GameController.Instance.players [i].activeSelf && (index < GameController.Instance.NumbersOfPlayers)) {
				GameController.Instance.OrderOfPlayer [index] = GameController.Instance.players [i];
				index++;
			}
		}
	}

    public void Submit() {
        IsCharacterToggleActive();
		if (isCharacterChoose) {
			counter++;
			isCharacterChoose = false;
			messageText.text = "Player " + counter;
			SetToggleNotActive ();  
			if (counter > GameController.Instance.NumbersOfPlayers) {
				SetActivePlayers ();
				selectCharacter.enabled = false;
				story.enabled = true;
			}    
		}
    }
}
