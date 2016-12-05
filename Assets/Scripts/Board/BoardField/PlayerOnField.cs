using UnityEngine;
using System.Collections;

public abstract class PlayerOnField : MonoBehaviour {

	public GameObject player = null;
	protected abstract void DoIt();

	void OnTriggerEnter2D(Collider2D collider) {
		if (player != null) {
			return;
		}

		if (collider.gameObject.tag == "Player")
			player = collider.gameObject;
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject == player)
			player = null;
	}
}
