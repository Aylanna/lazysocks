using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/**
 * This class manages the whole game process. Each game rule for the board has its own state.
 * 
 * @author Annkatrin Harms
 */
public class GameController : MonoBehaviour {

    public Canvas rollADice;
    public Canvas gameMenu;
	public Canvas startMenu;
	public Canvas endStory;

	public GameObject mainScene;
	private GameObject activePlayer;
	public List <GameObject> players;
	private GameObject[] orderOfPlayer;

	private bool isMinigamePlayed;
	private bool isDice;
	private bool deactivateDice;

	private int playerIDDice;
	private int playerIDMovement;
	private int diceValue;
	private int state;
	private int numbersOfPlayers;
	private int round = 1;

	private BoardController bc;
	private Dice dice;

	private static GameController instance;

	public static GameController Instance{
		get{
			return instance;
		}
	}

	public GameObject[] OrderOfPlayer {
		get{ return orderOfPlayer; }
		set{orderOfPlayer = value; }
	}

	public GameObject ActivePlayer {
		get{ return activePlayer; }
	}

	public bool IsMinigamePlayed {
		get{ return isMinigamePlayed; }
		set{isMinigamePlayed = value; }
	}

	public bool DeactivateDice   {
		get{ return deactivateDice; }
		set{deactivateDice   = value; }
	}

	public bool IsDice  {
		get{ return isDice; }
		set{isDice  = value; }
	}

	public int PlayerIDDice  {
		get{ return playerIDDice; }
		set{playerIDDice  = value; }
	}

	public int PlayerIDMovement {
		get{ return playerIDMovement; }
		set{playerIDMovement = value; }
	}

	public int DiceVaule {
		get{return diceValue; }
		set{diceValue = value; }
	}

	public int State {
		get{ return state; }
		set{state = value; }
	}
		
	public int NumbersOfPlayers {
		get{ return numbersOfPlayers; }
		set{numbersOfPlayers = value; }
	}
	public int Round {
		get{return round; }
	}
		
	void Awake() {
		if (instance == null) {
			instance = this;
			//DontDestroyOnLoad (gameObject);
		} else {
			//Destroy (gameObject);
		}
	}
    
    void Start() {
		dice = GetComponent<Dice> ();
		bc = GetComponent<BoardController> ();
		gameMenu.enabled = false;
		startMenu.enabled = true;    
		round = 1;
    }
 
    void Update() {
        switch(state) {
        	// Game preparation
			case 0:
			//	orderOfPlayer = new GameObject[numbersOfPlayers];
                break;

			//Player roll the dice for highscore
			case 1:
				PlayerRoleForHighscoreState ();
				break;

			//Player roll the dice
		case 2:
				PlayerDiceState ();
				break;

			//Player moves on the board 
			case 3:
				if (!rollADice.GetComponent<Canvas> ().isActiveAndEnabled) {
				gameMenu.GetComponent<GameMenu> ().DeactivateGameMessage ();
					bc.HandleBoardEvent ();
				state = 4; 
				}
				break;

			//Each field on the board has a special action
			case 4:
				bc.HandleFieldAct ();
				break;

			// Player got an extra dice
			case 5:
				gameMenu.GetComponent<GameMenu> ().SwitchGameMessage (1);
				deactivateDice = false;
				state = 11;
				break;

			//Player got an extra life
			case 6:
			if (activePlayer.GetComponent<PlayerController> ().IsExtraLife) {
					gameMenu.GetComponent<GameMenu> ().SwitchGameMessage (2);
				} 
				gameMenu.GetComponent<GameMenu> ().UpdateView ();
				state = 11;
				break;

			//Minigame/Bossbattle is played
			case 7:
				gameMenu.GetComponent<GameMenu> ().SwitchGameMessage (4);
				if (isMinigamePlayed) {
					isMinigamePlayed = false;
				    gameMenu.GetComponent<GameMenu> ().SetItemVisible (activePlayer.GetComponent<PlayerController> ().Items);
					gameMenu.GetComponent<GameMenu> ().UpdateView ();
				    gameMenu.GetComponent<GameMenu> ().DeactivateGameMessage ();
					if (activePlayer.GetComponent<PlayerController> ().IsGameWon) {
						gameMenu.enabled = false;
						endStory.enabled = true;
					} else {
						state = 10;
					}
				}
				//Else Wait for the end of the minigame
				break;

			//FieldAction Movement
			case 8:
				
				state = 11;
				break;

			//Player need to skip next round
			case 9:
		    	gameMenu.GetComponent<GameMenu> ().SwitchGameMessage (3);
			    activePlayer.GetComponent<PlayerController> ().SkipAt = round + 1;
				state = 11;
				break;

			//next player or new round
		case 10:
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

			//waiting state
			case 11: 
				break;

			//Player one the game
			case 12: 
				
				//SceneManager.LoadScene (0);
				StartCoroutine (FinishGame ());
				break;
		}
			
    }
	protected IEnumerator FinishGame() {
		yield return new WaitForSeconds (2.0f);
		endStory.enabled = false;
		SceneManager.LoadScene (0);
	}

	protected IEnumerator SetDice() {
		yield return new WaitForSeconds(2.0f);
		rollADice.enabled = false;
		gameMenu.enabled = true;
		gameMenu.GetComponent<GameMenu> ().UpdateView ();
		state = 3;
	}

	/**
	 * Each player need to role the dice to figure out an order for the board dice.
	 * After the order is fixed the player id is set to zero again to start with the first player.
	 * Also the dice gui is prepared for the game.
	 */
	void PlayerRoleForHighscoreState() {
		if(playerIDDice < numbersOfPlayers) {
			rollADice.GetComponent<Canvas>().enabled = true;
			activePlayer = orderOfPlayer [playerIDDice];
			dice.messageText.text =activePlayer.GetComponent<PlayerController> ().playerName;
			deactivateDice = false;
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
	}

	/**
	 * If a player throws the same dice value then an other player, 
	 * he needs to throw the dice again until a unique value is diced.
	 * Otherwise next player will dice.
	 */
	public bool isEqualHighScore() {
		for (int i = 0; i < orderOfPlayer.Length; i++) {
			if (activePlayer.GetComponent<PlayerController>().DiceValue == orderOfPlayer [i].GetComponent<PlayerController>().DiceValue
				&& playerIDDice != i) {
				return true;
			}
		}
		return false;
	}
		
	/**
	 * After each player roll a dice for player order the array is sort after the attribute dive value.
	 * The player with the highest value will start the game. 
	 */
	public void SortOrderOfPlayers()
	{
		Array.Sort(orderOfPlayer,
			delegate (GameObject player1, GameObject player2) { return - player1.GetComponent<PlayerController>().DiceValue.
				CompareTo(player2.GetComponent<PlayerController>().DiceValue); });
	}

	/**
	 * Waiting routine for Highscore state
	 */
	protected IEnumerator HighScoreState() {
		yield return new WaitForSeconds(1.0f);
		state = 2;
	}

	/**
	 * Manages the player dice. Before a player can roll the dice it is nessesary to check if player is dead, 
	 * needs to play bossbattle again and check if player need to skip. 
	*/
	void PlayerDiceState() {
		activePlayer = orderOfPlayer [playerIDDice];
		gameMenu.GetComponent<GameMenu> ().DeactivateGameMessage ();
		gameMenu.GetComponent<GameMenu> ().enabled = false;
		rollADice.enabled = false;
		if (activePlayer.GetComponent<PlayerController> ().IsDying) {
		    activePlayer.GetComponent<Movement> ().ProcessDying();
			state = 11;
			StartCoroutine (HighScoreState());
		} 
		if (!activePlayer.GetComponent<PlayerController> ().IsPlayerInBossBattleState ()) {
			rollADice.enabled = true;
			ProcessSkipState ();
		} else {
			activePlayer.GetComponent<PlayerController> ().DiceValue = 0;
			state = 3;
		}
	}

	/**
	 * If a player needs to skip the actual round then the next player will be choose and roll the dice.
	 * Otherwise the Coroutine for the dice will start.
	 */
	void ProcessSkipState() {
		if (activePlayer.GetComponent<PlayerController> ().SkipAt == round) {
			state = 10;
		} else {
			dice.messageText.text = activePlayer.GetComponent<PlayerController> ().playerName;
			if (isDice) {
				StartCoroutine (SetDice ());
				isDice = false;
			}
		}
	}
		
	/**
	 * Remove a skip turn from a player and set skip round to -1 again. 
	 */
	void RemoveSkip() {
		for (int i = 0; i < orderOfPlayer.Length; i++) {
			if (orderOfPlayer [i].GetComponent<PlayerController> ().SkipAt  == (round - 1) && (round > - 1)) {
				orderOfPlayer [i].GetComponent<PlayerController> ().SkipAt = -1;
			}
		}
	}
}
