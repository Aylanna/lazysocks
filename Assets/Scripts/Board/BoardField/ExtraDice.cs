using UnityEngine;
using System.Collections;

public class ExtraDice : BoardField {


	public override void DoFieldAction () {
		gc.state = 5;
		StartCoroutine (StartWaitingState());
	 

	}

	protected IEnumerator StartWaitingState() {
		yield return new WaitForSeconds(2.0f);
		gc.state = 2;

	}
}
