using UnityEngine;
using System.Collections;

public class Skip : FieldAct {

	private GameController gc;
	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();

	}
	public override void DoFieldAction () {
		gc.state = 9;
		StartCoroutine (StartWaitingState());

	}

	protected IEnumerator StartWaitingState() {
		yield return new WaitForSeconds(2.0f);
		gc.state = 10;

	}
}
