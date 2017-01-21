using UnityEngine;
using System.Collections;

public class ExtraLife : BoardField {



	public override void DoFieldAction () {
		gc.activePlayer.GetComponent<PlayerController> ().LifePointsManager ();
		gc.state = 6;
		StartCoroutine (StartWaitingState());

	}

	protected IEnumerator StartWaitingState() {
		yield return new WaitForSeconds(2.0f);
		gc.state = 10;

	}
}
