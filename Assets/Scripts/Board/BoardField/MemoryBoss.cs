using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBoss : BoardField {


	public override void DoFieldAction () {
		gc.state = 7;
		scl.SetSceneIndex (4);
		scl.LoadMinigame ();
	}
}
