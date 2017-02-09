using UnityEngine;
using System.Collections;

/**
 * This class mamange the extra dice fieldaction.
 * 
 * @author Annkatrin Harms
 */
public class ExtraDice : BoardField {

	public override void DoFieldAction () {
		GameController.Instance.State = 5;
		StartCoroutine (StartWaitingState());
	}

	protected IEnumerator StartWaitingState() {
		yield return new WaitForSeconds(2.0f);
		GameController.Instance.gameMenu.GetComponent<GameMenu> ().DeactivateGameMessage ();
		GameController.Instance.State = 2;
	}
}
