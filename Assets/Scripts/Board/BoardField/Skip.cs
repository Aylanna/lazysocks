using UnityEngine;
using System.Collections;

public class Skip : BoardField {


	public override void DoFieldAction () {
		gc.state = 9;
		StartCoroutine (StartWaitingState());

	}

	protected IEnumerator StartWaitingState() {
		yield return new WaitForSeconds(2.0f);
		gc.state = 10;

	}
}
