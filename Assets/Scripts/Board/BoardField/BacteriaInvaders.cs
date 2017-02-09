using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class mamange to load minigame Bacteria Invaders.
 * 
 * @author Annkatrin Harms
 */
public class BacteriaInvaders : BoardField{

	public override void DoFieldAction () {
		GameController.Instance.State = 7;
		scl.SetSceneIndex (bacterialInvadersID);
		StartCoroutine (StartMinigame ());
	}

	protected IEnumerator StartMinigame() {
		yield return new WaitForSeconds(2.0f);
		scl.LoadMinigame ();
	}
}
