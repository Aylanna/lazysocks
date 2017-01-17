using UnityEngine;
using System.Collections;

public class ExtraLife : FieldAct {
	
	private GameController gc;
	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();

	}
	public override void DoFieldAction () {
		gc.activePlayer.GetComponent<PlayerController> ().AddLifePoints ();
		gc.state = 6;
		StartCoroutine (StartWaitingState());

	}

	protected IEnumerator StartWaitingState() {
		yield return new WaitForSeconds(2.0f);
		gc.state = 10;

	}
}
