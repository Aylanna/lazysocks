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
	private BoardController bc;
    public GameObject[] players;
    public int numbersOfPlayers = 0;
    private GameObject[] orderOfPlayer;
    public bool isDice = false;
    private Dice dice;

	public GameObject startField;


    void Start()
    {
		//orderOfPlayer = new GameObject[numbersOfPlayers];
		//dice = GetComponent<Dice> ();
		//bc = GetComponent<BoardController> ();
       
    }
 
    void Update()
    {
        switch(state)
        {
            // Game preparation
		case 0:
			orderOfPlayer = new GameObject[numbersOfPlayers];
			dice = GetComponent<Dice> ();
			bc = GetComponent<BoardController> ();
                break;
			//Player role for highscore
            case 1:
                if(playerIDDice < numbersOfPlayers) {
                    rollADice.GetComponent<Canvas>().enabled = true;
					activePlayer = players [playerIDDice];
					dice.messageText.text = activePlayer.GetComponent<PlayerController> ().playerName;
					if (isDice) {
						orderOfPlayer [playerIDDice] = activePlayer;
						playerIDDice++;
					    rollADice.GetComponent<Canvas> ().enabled = false;
						isDice = false;
					}
                }
                else
                {
					rollADice.GetComponent<Canvas> ().enabled = false;
                    SortOrderOfPlayers();
                   // TestPlayerOrder();
					playerIDDice = 0;
					isDice = false;
                    state = 2;
                }
			break;
		//Player dice
		case 2:
			activePlayer = orderOfPlayer [playerIDDice];
			rollADice.GetComponent<Canvas> ().enabled = true;
			dice.messageText.text = activePlayer.GetComponent<PlayerController> ().playerName;
			if (isDice) {
				Invoke ("SetDiceCanvasInactive", 1);
				isDice = false;
				state = 3;
			}
			break;
		//Player moves
		case 3:
			bc.HandleBoardEvent ();
			state = 4;  
			break;
		//next player or new round
		case 4:
			if (playerIDDice < orderOfPlayer.Length - 1) {
				playerIDDice++;
			} else {
				playerIDDice = 0;
			}
			state = 2;
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
