using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    public Canvas selectCharacter;
    public Canvas start;
    public Canvas rollTheDice;

    private PlayerController player;
    private GameController controller;
    
    private Toggle[] numbersOfPlayers;

    void Start () {

        controller = GetComponent<GameController>();
        selectCharacter.GetComponent<Canvas>().enabled = false;
        rollTheDice.GetComponent<Canvas>().enabled = false;
        numbersOfPlayers = start.GetComponent<Canvas>().GetComponentsInChildren<Toggle>();
        foreach (Toggle t in numbersOfPlayers)
        {
            t.isOn = false;
        }
    }

    void IsNumbersOfPlayersToggleActive()
    {
        foreach (Toggle t in numbersOfPlayers)
        {
            if (t.isOn)
                controller.numbersOfPlayers = int.Parse(t.GetComponentInChildren<Text>().text);

        }
    }

    public void Submit()
    {
        IsNumbersOfPlayersToggleActive();
        start.GetComponent<Canvas>().enabled = false;
        selectCharacter.GetComponent<Canvas>().enabled = true;
    }


	
	
}
