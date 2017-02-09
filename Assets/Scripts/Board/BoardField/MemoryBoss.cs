using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class mamange to load minigame Memory Boss.
 * 
 * @author Annkatrin Harms
 */
public class MemoryBoss : BoardField {

	public override void DoFieldAction () {
		GameController.Instance.State = 7;
		scl.SetSceneIndex (memoryBossID);
		StartCoroutine (StartMinigame ());
	}

	protected IEnumerator StartMinigame() {
		yield return new WaitForSeconds(2.0f);
		scl.LoadMinigame ();
	}
}
