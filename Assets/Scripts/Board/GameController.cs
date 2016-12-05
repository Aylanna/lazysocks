using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

   public Canvas rollADice;
   // public int playerIDMovement;
    public int playerIDDice;
	public int playerIDMovement;
    public int diceValue;
    public GameObject activePlayer; 
    public int state = 0;
    
    public GameObject[] players;
    public int numbersOfPlayers = 0;
    private GameObject[] orderOfPlayer;
    public bool isDice = false;
    private Dice dice;


    void Start()
    {
       
    }
 
    void Update()
    {
        switch(state)
        {
            // Game preparation
            case 0:
                orderOfPlayer = new GameObject[numbersOfPlayers];
                dice = GetComponent<Dice>();
                break;
            case 1:
                if(playerIDDice < numbersOfPlayers) {
                    rollADice.GetComponent<Canvas>().enabled = true;
					activePlayer = players [playerIDDice];
					dice.messageText.text = activePlayer.GetComponent<PlayerController> ().playerName;
					if (isDice) {
						orderOfPlayer [playerIDDice] = activePlayer;
						playerIDDice++;
						isDice = false;
					}
                }
                else
                {
				
                  //  Invoke("SetDiceCanvasInactive", 1);
				rollADice.GetComponent<Canvas> ().enabled = false;
                    SortOrderOfPlayers();
                   // TestPlayerOrder();
					playerIDDice = 0;
					isDice = false;
                    state = 2;
                }
                break;
		case 2:
			
			activePlayer = orderOfPlayer [playerIDDice];
			Debug.Log ("order " + orderOfPlayer.Length + " " + "ID " + playerIDDice);
			rollADice.GetComponent<Canvas> ().enabled = true;
			dice.messageText.text = activePlayer.GetComponent<PlayerController> ().playerName;

			if (isDice) {
				Invoke ("SetDiceCanvasInactive", 1);
				isDice = false;
				state = 3;
			}
                break;
		case 3:
			Debug.Log ("Player moves " + activePlayer.GetComponent<PlayerController> ().playerName);
			Debug.Log ("Player Field interaction " + activePlayer.GetComponent<PlayerController> ().playerName);
			if (playerIDDice < orderOfPlayer.Length) {
				//Debug.Log ("ID " + playerIDDice);
				playerIDDice++;
				state = 2;
			} else {
				state = 4;
			}
                //Player move
                // player interact
                //for now:
               
                break;
            case 4:
                //move activePlayer
                break;
        }
    }

    public void SetDiceCanvasInactive()
    {
        rollADice.GetComponent<Canvas>().enabled = false;
    }
    public void SortOrderOfPlayers()
    {
        Array.Sort(orderOfPlayer,
     delegate (GameObject player1, GameObject player2) { return - player1.GetComponent<PlayerController>().GetDiceValue().
         CompareTo(player2.GetComponent<PlayerController>().GetDiceValue()); });
    }

    public void TestPlayerOrder()
    {
        Debug.Log("Order of Player: ");
        foreach(GameObject p in orderOfPlayer)
        {
            Debug.Log(p.GetComponent<PlayerController>().playerName + "   " + p.GetComponent<PlayerController>().GetDiceValue().ToString());
        }
    }

    public void SetPlayerIDDice(int playerIDDice)
    {
        this.playerIDDice = playerIDDice;
    }

    public int GetPlayerIDDice()
    {
        return playerIDDice;
    }

}
