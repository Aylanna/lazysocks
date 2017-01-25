using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKong : BoardField {


	public override void DoFieldAction() {
		gc.state = 7;
		scl.SetSceneIndex (6);
		StartCoroutine (StartMinigame ());
	}

	protected IEnumerator StartMinigame()
	{
		yield return new WaitForSeconds(2.0f);
		scl.LoadMinigame ();

	}
}
