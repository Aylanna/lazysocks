using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour {

    public Canvas selectCharacter;
    public Text messageText;
    public Canvas rollADie;
    private int counter = 1;
    private PlayerController player;
    private GameController controller;

    private Toggle[] characters;

    void Start()
    {

        controller = GetComponent<GameController>();
        characters = selectCharacter.GetComponent<Canvas>().GetComponentsInChildren<Toggle>();
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
        foreach (Toggle t in characters)
        {
            if (t.isOn)
                Debug.LogWarning("Selected Player " + counter);

        }
    }

    public void Submit()
    {
        
        if (counter != controller.numbersOfPlayers) { 
            IsCharacterToggleActive();
            messageText.text = "Player " + counter;
            SetToggleNotActive();
            counter++;
        } else
        {
            selectCharacter.GetComponent<Canvas>().enabled = false;
            rollADie.GetComponent<Canvas>().enabled = true;
        }
        
    }
}
