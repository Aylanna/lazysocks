using UnityEngine;
using System.Collections;

public class ExtraLife : FieldAct {
	
	private GameController gc;
	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();

	}
	public override void DoFieldAction () {
		gc.state = 6;
		Debug.Log ("Extra Life");

	}
}
