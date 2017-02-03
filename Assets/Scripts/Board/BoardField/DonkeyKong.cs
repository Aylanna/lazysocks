using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class mamange to load minigame Donkey Kong.
 * 
 * @author Annkatrin Harms
 */
public class DonkeyKong : BoardField {

	public override void DoFieldAction() {
		GameController.Instance.State = 7;
		scl.SetSceneIndex (donkeyKongID);
		StartCoroutine (StartMinigame ());
	}

	protected IEnumerator StartMinigame() {
		yield return new WaitForSeconds(2.0f);
		scl.LoadMinigame ();
	}
}
