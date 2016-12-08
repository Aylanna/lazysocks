using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

	private GameController gc;
	//protected abstract void DoIT ();
	// Use this for initialization
	void Start () {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
	}
	
	public void HandleBoardEvent() {
		Movement move = gc.activePlayer.GetComponent<Movement> ();
		move.currentWayPointID += gc.activePlayer.GetComponent<PlayerController> ().GetDiceValue ();
		move.SetMove (true);
		//DoIT ();
	}
}
