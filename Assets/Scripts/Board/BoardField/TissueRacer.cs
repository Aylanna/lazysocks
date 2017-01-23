using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueRacer : BoardField {


	public override void DoFieldAction () {
		gc.state = 7;
		Debug.Log ("Tissue Racer");
		scl.SetSceneIndex (2);
		scl.LoadMinigame ();
	}
}
