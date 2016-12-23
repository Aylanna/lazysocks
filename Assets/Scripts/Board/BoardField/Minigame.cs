using UnityEngine;
using System.Collections;

public class Minigame : FieldAct {
	private GameController gc;

	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();

	}
	public override void DoFieldAction () {
		gc.state = 7;
		Debug.Log ("Mini Game");

	}
}
