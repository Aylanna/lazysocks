using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackAMole : BoardField  {

	public override void DoFieldAction() {
		gc.state = 7;
		scl.SetSceneIndex (1);
		scl.LoadMinigame ();
	}
}
