using UnityEngine;
using System.Collections;

/**
 * This class mamange the skip fieldaction.
 * 
 * @author Annkatrin Harms
 */
public class Skip : BoardField {

	public override void DoFieldAction () {
		GameController.Instance.State = 9;
		StartCoroutine (StartWaitingState());
	}

	protected IEnumerator StartWaitingState() {
		yield return new WaitForSeconds(2.0f);
		GameController.Instance.State = 10;
	}
}
