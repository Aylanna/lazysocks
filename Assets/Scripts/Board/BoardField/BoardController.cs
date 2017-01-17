using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

	private GameController gc;
	private Movement move;

	// Use this for initialization
	void Start () {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
	}
	
	public void HandleBoardEvent() {
	    move = gc.activePlayer.GetComponent<Movement> ();
		move.currentWayPointID += gc.activePlayer.GetComponent<PlayerController> ().GetDiceValue ();
		move.SetMove (true);
	}

	public bool HandleFieldAct() {
		if(!move.GetMove()) {
			FieldAct field = move.GetCurrentField ().GetComponent<FieldAct>();
			field.DoFieldAction ();
			return true;
		}
		return false;
	}
}
