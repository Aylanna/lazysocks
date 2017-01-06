using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Action : MonoBehaviour {

	public Sprite cleanHand;

	void KillMe() {
		Destroy (gameObject, 0.4f);
	}

	void WashMe() {
		gameObject.GetComponentInChildren<SpriteRenderer> ().sprite = cleanHand;
		Destroy (gameObject, 0.4f);
	}
}
