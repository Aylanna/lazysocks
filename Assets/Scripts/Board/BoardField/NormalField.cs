using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalField : BoardField {
	
	public override void DoFieldAction () {
		if (gc.activePlayer.GetComponent<PlayerController> ().IsGameWon ())
			gc.state = 12;
		else
			gc.state = 10;

	}

}
