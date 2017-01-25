using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBossBattle2 : BoardField {



	public override void DoFieldAction () {
		
		if (gc.activePlayer.GetComponent<PlayerController> ().GetItem () == 1) {
			if (gc.activePlayer.GetComponent<PlayerController> ().IsPlayerInBossBattleState ()) {
				gc.activePlayer.GetComponent<PlayerController> ().SetItem ();
				gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle1 (false);
				gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle2 (false);
				gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle3 (false);
			} else {
				gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle2 (true);
			}
		}
		gc.state = 10;


	}
}
