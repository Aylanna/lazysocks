using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour {


	public UiManagerBrickBreaker ui;
	// Use this for initialization
	void Start () {
		ui = GameObject.FindWithTag ("ui").GetComponent<UiManagerBrickBreaker> ();
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Ball") {
			ui.IncrementScore ();
			Destroy (gameObject);
		}
	}
}
