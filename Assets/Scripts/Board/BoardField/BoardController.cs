using UnityEngine;
using System.Collections;

/**
 * This class mamange the movement on board and fieldaction.
 * 
 * @author Annkatrin Harms
 */
public class BoardController : MonoBehaviour {

	private Movement move;

	public void HandleBoardEvent() {
		move = GameController.Instance.ActivePlayer.GetComponent<Movement> ();
		move.currentWayPointID += GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().DiceValue;
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
