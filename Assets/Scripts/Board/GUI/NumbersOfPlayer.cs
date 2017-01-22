using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumbersOfPlayer : MonoBehaviour {

    public Canvas selectCharacter;
    public Canvas numbersOfPlayer;
    public Canvas rollTheDice;


    private PlayerController player;
    private GameController controller;
	private bool isChoose;
    private Toggle[] numbersOfPlayers;

    void Start () {
		numbersOfPlayer.enabled = false;
        controller = GetComponent<GameController>();
        selectCharacter.enabled = false;
        rollTheDice.enabled = false;
		numbersOfPlayers = numbersOfPlayer.GetComponent<Canvas>().GetComponentsInChildren<Toggle>();
        foreach (Toggle t in numbersOfPlayers)
        {
            t.isOn = false;
        }
    }

    void IsNumbersOfPlayersToggleActive()
    {
        foreach (Toggle t in numbersOfPlayers)
        {
			if (t.isOn) {
				controller.numbersOfPlayers = int.Parse (t.GetComponentInChildren<Text> ().text);
				isChoose = true;
			}

        }
    }

    public void Submit()
    {
        IsNumbersOfPlayersToggleActive();
		if (isChoose) {
			isChoose = false;
			numbersOfPlayer.enabled = false;
			selectCharacter.enabled = true;
		}
    }




	
	
}
