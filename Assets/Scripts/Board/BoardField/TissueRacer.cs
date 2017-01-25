using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueRacer : BoardField {


	public override void DoFieldAction () {
		gc.state = 7;
		Debug.Log ("Tissue Racer");
		scl.SetSceneIndex (2);
		StartCoroutine (StartMinigame ());
	}

	protected IEnumerator StartMinigame()
	{
		yield return new WaitForSeconds(2.0f);
		scl.LoadMinigame ();

	}
}
