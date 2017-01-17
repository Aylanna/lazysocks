using UnityEngine;
using System.Collections;

public class FieldActMovement : FieldAct {

	private GameController gc;
	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();

	}
	public override void DoFieldAction () {
		int steps = Random.Range(-3, 4);
		gc.activePlayer.GetComponent<PlayerController> ().SetDiceValue (steps);
		gc.state = 8;
		StartCoroutine (StartWaitingState());
	}

	protected IEnumerator StartWaitingState() {
		yield return new WaitForSeconds(2.0f);
		gc.state = 3;

	}
}
