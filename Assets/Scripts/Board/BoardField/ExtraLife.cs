using UnityEngine;
using System.Collections;

/**
 * This class mamange the extra life fieldaction.
 * 
 * @author Annkatrin Harms
 */
public class ExtraLife : BoardField {

	public override void DoFieldAction () {
		GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().AddLifePoints();
		GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsExtraLife = true;
		GameController.Instance.State = 6;
		StartCoroutine (StartWaitingState());
	}

	protected IEnumerator StartWaitingState() {
		yield return new WaitForSeconds(2.0f);
		GameController.Instance.State = 10;
	}
}
