using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class mamange to load minigame Tissue Racer.
 * 
 * @author Annkatrin Harms
 */
public class TissueRacer : BoardField {

	public override void DoFieldAction () {
		GameController.Instance.State = 7;
		scl.SetSceneIndex (tissueRacerID);
		StartCoroutine (StartMinigame ());
	}

	protected IEnumerator StartMinigame() {
		yield return new WaitForSeconds(2.0f);
		scl.LoadMinigame ();
	}
}
