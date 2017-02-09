using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * This class manage to destroy an object and change the sprite to a clean hand.
 * 
 * @author Annkatrin Harms
 */
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
