using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKong : BoardField {


	public override void DoFieldAction() {
		gc.state = 7;
		scl.SetSceneIndex (6);
		scl.LoadMinigame ();
	}
}
