using UnityEngine;
using System.Collections;

public class ExtraDice : FieldAct {

	private GameController gc;

	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();

	}
	public override void DoFieldAction () {
		gc.state = 5;
	 Debug.Log ("Extra Dice");

	}
}
