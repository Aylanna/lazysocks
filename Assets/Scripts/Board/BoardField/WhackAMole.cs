using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class mamange to load minigame Whack a Mole
 * 
 * @author Annkatrin Harms
 */
public class WhackAMole : BoardField  {

	public override void DoFieldAction() {
		GameController.Instance.State = 7;
		scl.SetSceneIndex (whackAMoleID);
		StartCoroutine (StartMinigame ());
	}

	protected IEnumerator StartMinigame() {
		yield return new WaitForSeconds(2.0f);
		scl.LoadMinigame ();
	}
}
