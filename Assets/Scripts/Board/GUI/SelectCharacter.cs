using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour {

    public Canvas selectCharacter;
    public Text messageText;
    public Canvas rollADice;
    private bool isDice = false;
    private int counter = 1;
    private PlayerController player;
    private GameController controller;

    private Toggle[] characters;

    void Start()
    {
        controller = GetComponent<GameController>();
        characters = selectCharacter.GetComponent<Canvas>().GetComponentsInChildren<Toggle>();
        rollADice.GetComponent<Canvas>().enabled = false;
        SetToggleNotActive();
    }

    void Update()
    {
        if (counter > controller.numbersOfPlayers && isDice)
        {
            selectCharacter.GetComponent<Canvas>().enabled = false;
            controller.state = 1;
            
        }
        if (controller.numbersOfPlayers > 0)
            isDice = true;
    
       
        
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
               // Debug.Log("Selected Character " + i + " from Player " + counter);
                controller.players[i].SetActive(true);
               
            }
        }
    }

    public void Submit()
    {
        counter++;
        IsCharacterToggleActive();
        messageText.text = "Player " + counter;
        SetToggleNotActive();  
           
    }
}
