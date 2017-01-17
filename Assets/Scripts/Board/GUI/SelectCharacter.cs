using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour {

    public Canvas selectCharacter;
	public Color disableColor = Color.gray;
    public Text messageText;
    public Canvas rollADice;
    private bool isDice = false;
    private int counter = 1;
    private PlayerController player;
    private GameController controller;
	private Toggle activeToggle;

    private Toggle[] characters;

    void Start()
    {
        controller = GetComponent<GameController>();
        characters = selectCharacter.GetComponent<Canvas>().GetComponentsInChildren<Toggle>();
        rollADice.GetComponent<Canvas>().enabled = false;
        SetToggleNotActive();
    }
		

    void SetToggleNotActive()
    {
        foreach (Toggle t in characters)
        {
            t.isOn = false;
        }
    }

    void IsCharacterToggleActive()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].isOn)
            {
                controller.players[i].SetActive(true);
				characters [i].enabled = false;  
				characters [i].gameObject.SetActive (false);
            }
        }
    }

	void SetActivePlayers() {
		int index = 0;
		for (int i = 0; i < controller.players.Count; i++) {
			if (controller.players [i].activeSelf && (index < controller.numbersOfPlayers)) {
				controller.orderOfPlayer [index] = controller.players [i];
				index++;
			}
		}

	}

    public void Submit()
    {
        counter++;
        IsCharacterToggleActive();
        messageText.text = "Player " + counter;
        SetToggleNotActive();  
		if (counter > controller.numbersOfPlayers)
		{
			SetActivePlayers ();
			selectCharacter.enabled = false;
			controller.state = 1;
		}          
    }
}
