using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBassBattle1 : BoardField {



	public override void DoFieldAction () {
		
		if (gc.activePlayer.GetComponent<PlayerController> ().GetItem () == 0) {
			if (gc.activePlayer.GetComponent<PlayerController> ().IsPlayerInBossBattleState ()) {
				gc.activePlayer.GetComponent<PlayerController> ().SetItem ();
				gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle1 (false);
				gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle2 (false);
				gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle3 (false);
				Debug.Log ("Set BossBattle false");
			} else {
				Debug.Log ("Set BossBattle true");
				gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle1 (true);
			}
		}
		gc.state = 10;


	}
}
