using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Canvas rollADice;
    public Canvas gameMenu;
	public Canvas playerOrder;
	public Canvas startMenu;
	public bool isMinigamePlayed;
	public GameObject mainScene;
    public int playerIDDice;
	public int playerIDMovement;
    public int diceValue;
    public GameObject activePlayer; 
    public int state = 0;
	private BoardController bc;
    public List <GameObject> players;
    public int numbersOfPlayers = 0;
    public GameObject[] orderOfPlayer;
    public bool isDice = false;
	public bool deactivateDice;
    private Dice dice;
	private int round = 1;
	public GameObject startField;




    void Start() {
		dice = GetComponent<Dice> ();
		bc = GetComponent<BoardController> ();
		gameMenu.enabled = false;
		gameMenu.GetComponent<GameMenu> ().SetFieldEventMessage (" ");
		startMenu.enabled = true;    
    }
 
    void Update() {
        switch(state) {
        	// Game preparation
			case 0:
				orderOfPlayer = new GameObject[numbersOfPlayers];
		   		 //waiting to start the game
                break;

			//Player role for highscore
            case 1:
                if(playerIDDice < numbersOfPlayers) {
					DiceForHighscore ();
                }
                else
                {
                SortOrderOfPlayers();
				StartCoroutine (HighScoreState());
				isDice = false;
				dice.SetDiceActive ();
				dice.SetMessage ("Round: " + round.ToString());
				playerIDDice = 0;
				dice.InActivateNextPlayer ();
			
			}
			break;

			//Player dice
			case 2:
			activePlayer = orderOfPlayer [playerIDDice];
			gameMenu.GetComponent<GameMenu> ().enabled = false;
			if (IsActivePlayerDead()) {
				
			} 
			if (!activePlayer.GetComponent<PlayerController> ().IsPlayerInBossBattleState ()) {
				
				rollADice.enabled = true;
				ProcessSkipState ();
			} else {
				activePlayer.GetComponent<PlayerController> ().SetDiceValue (0);
				state = 3;
			}

			break;

			//Player moves
			case 3:

				if (!rollADice.GetComponent<Canvas> ().isActiveAndEnabled) {
					bc.HandleBoardEvent ();
					if (activePlayer.GetComponent<PlayerController> ().IsGameWon ()){
						state = 12;
				} else {
						state = 4; 
					}
				}
				break;

			//FieldAct
			case 4:
				bc.HandleFieldAct ();
				break;

			//ExtraDice
			case 5:
				gameMenu.GetComponent<GameMenu> ().SwitchGameMessage (1);
				deactivateDice = false;
				state = 11;
				break;

			//ExtraLife
			case 6:
				if (activePlayer.GetComponent<PlayerController> ().IsExtraLife ()) {
					gameMenu.GetComponent<GameMenu> ().SwitchGameMessage (2);
				} 
				gameMenu.GetComponent<GameMenu> ().UpdateView ();
				state = 11;
				break;

			//Minigame/Bossbattle
			case 7:
				gameMenu.GetComponent<GameMenu> ().SwitchGameMessage (4);
				if (isMinigamePlayed) {
					isMinigamePlayed = false;
					gameMenu.GetComponent<GameMenu> ().SetItemVisible (activePlayer.GetComponent<PlayerController> ().GetItem ());
					gameMenu.GetComponent<GameMenu> ().UpdateView ();
				    gameMenu.GetComponent<GameMenu> ().DeactivateGameMessage ();
					state = 10;
				}
				//Else Wait for the end of the minigame
				break;

			//FieldAction Movement
			case 8:
				state = 11;
				break;

			case 9:
		    	gameMenu.GetComponent<GameMenu> ().SwitchGameMessage (3);
				activePlayer.GetComponent<PlayerController> ().SetSkipAt (round + 1);
				state = 11;
				break;

			//next player or new round
			case 10:
				gameMenu.GetComponent<GameMenu> ().DeactivateGameMessage ();
				gameMenu.GetComponent<GameMenu> ().UpdateView ();
				rollADice.enabled = false;
				if (playerIDDice < orderOfPlayer.Length - 1) {
					playerIDDice++;
				} else {
					playerIDDice = 0;
					round++;
					RemoveSkip ();
					dice.SetMessage ("Round: " + round.ToString ());
				}
				deactivateDice = false;
				dice.SetStartDice ();
				state = 2;
        		break;

			//waiting state1
			case 11: 
				break;

			case 12: 
				gameMenu.GetComponent<GameMenu> ().SetFieldEventMessage (activePlayer.GetComponent<PlayerController> ().playerName + " Won!");
				StartCoroutine (FinishGame ());
				break;
		}
			
    }
	protected IEnumerator FinishGame() {
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene (0);
	}

	protected IEnumerator SetDice() {
		yield return new WaitForSeconds(2.0f);
		rollADice.enabled = false;
		gameMenu.enabled = true;

		gameMenu.GetComponent<GameMenu> ().UpdateView ();
		gameMenu.GetComponent<GameMenu> ().SetFieldEventMessage (" ");
		state = 3;


	}

	public void SortOrderOfPlayers()
	{
		Array.Sort(orderOfPlayer,
			delegate (GameObject player1, GameObject player2) { return - player1.GetComponent<PlayerController>().GetDiceValue().
				CompareTo(player2.GetComponent<PlayerController>().GetDiceValue()); });
	}

	public bool isEqualHighScore() {
		for (int i = 0; i < orderOfPlayer.Length; i++) {
			if (activePlayer.GetComponent<PlayerController>().GetDiceValue() == orderOfPlayer [i].GetComponent<PlayerController>().GetDiceValue()
				&& playerIDDice != i) {
				return true;
			}
		}
		return false;
	}
 

	void DiceForHighscore() {
		rollADice.GetComponent<Canvas>().enabled = true;
		activePlayer = orderOfPlayer [playerIDDice];
		dice.messageText.text = activePlayer.GetComponent<PlayerController> ().playerName;
		deactivateDice = false;
	}

	void RemoveSkip() {
		for (int i = 0; i < orderOfPlayer.Length; i++) {
			if (orderOfPlayer [i].GetComponent<PlayerController> ().GetSkipAt () == (round - 1) && (round > - 1)) {
				orderOfPlayer [i].GetComponent<PlayerController> ().SetSkipAt (-1);
			}
		}
	}


	protected IEnumerator HighScoreState() {
		yield return new WaitForSeconds(1.0f);
		state = 2;
	}

	bool IsActivePlayerDead() {
		if (activePlayer.GetComponent<PlayerController> ().IsDying ()) {
			activePlayer.GetComponent<Movement> ().ProcessDying();
			return true;
		} else {
			return false;
		}
	}


	void ProcessSkipState() {
		if (activePlayer.GetComponent<PlayerController> ().GetSkipAt () == round) {
			state = 10;
		} else {
			dice.messageText.text = activePlayer.GetComponent<PlayerController> ().playerName;
			if (isDice) {
				StartCoroutine (SetDice ());
				isDice = false;
			}
		}
	}
}
