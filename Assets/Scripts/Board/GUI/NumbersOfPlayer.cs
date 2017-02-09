using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * This class mamange the number of players menu for the game.
 * 
 * @author Annkatrin Harms
 */
public class NumbersOfPlayer : MonoBehaviour {

    public Canvas selectCharacter;
    public Canvas numbersOfPlayer;
    public Canvas rollTheDice;
    private PlayerController player;
	private bool isChoose;
    private Toggle[] numbersOfPlayers;

    void Start () {
		numbersOfPlayer.enabled = false;
        selectCharacter.enabled = false;
        rollTheDice.enabled = false;
		numbersOfPlayers = numbersOfPlayer.GetComponent<Canvas>().GetComponentsInChildren<Toggle>();
        foreach (Toggle t in numbersOfPlayers) {
            t.isOn = false;
        }
    }

	/**
	 * Manages the selection of each Toggle. 
	 */
    void IsNumbersOfPlayersToggleActive() {
        foreach (Toggle t in numbersOfPlayers) {
			if (t.isOn) {
				GameController.Instance.NumbersOfPlayers = int.Parse (t.GetComponentInChildren<Text> ().text);
				isChoose = true;
			}
        }
    }

    public void Submit() {
        IsNumbersOfPlayersToggleActive();
		if (isChoose) {
			isChoose = false;
			numbersOfPlayer.enabled = false;
			selectCharacter.enabled = true;
			GameController.Instance.OrderOfPlayer = new GameObject[GameController.Instance.NumbersOfPlayers];
		}
    }
}
