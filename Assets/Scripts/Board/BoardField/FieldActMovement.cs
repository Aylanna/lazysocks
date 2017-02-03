using UnityEngine;
using System.Collections;

/**
 * This class mamange the extra movement fieldaction.
 * 
 * @author Annkatrin Harms
 */
public class FieldActMovement : BoardField {

	public override void DoFieldAction () {
		int steps = Random.Range(-3, 4);
		GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().DiceValue = steps;
		GameController.Instance.State = 8;
		StartCoroutine (StartWaitingState());
	}

	protected IEnumerator StartWaitingState() {
		yield return new WaitForSeconds(2.0f);
		GameController.Instance.State = 3;
	}
}
