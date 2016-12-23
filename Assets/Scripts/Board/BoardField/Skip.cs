using UnityEngine;
using System.Collections;

public class Skip : FieldAct {

	private GameController gc;
	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();

	}
	public override void DoFieldAction () {
		gc.state = 9;
		Debug.Log ("Skip");

	}
}
