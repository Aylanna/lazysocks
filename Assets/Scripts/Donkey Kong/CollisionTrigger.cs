using UnityEngine;
using System.Collections;

public class CollisionTrigger : MonoBehaviour {

	private BoxCollider2D playerCollider; 

	[SerializeField] private PolygonCollider2D platformCollider; 
	[SerializeField] private PolygonCollider2D platformTrigger;

	// init
	void Start () {
		playerCollider = GameObject.Find ("Player").GetComponent<BoxCollider2D> (); 
		Physics2D.IgnoreCollision (platformCollider, platformTrigger, true);
	}

	/**
	 * Ignore the collission if the player is entering the trigger
	 */ 
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "Player") {
			Physics2D.IgnoreCollision (platformCollider, playerCollider, true);
		}
	}
	/*
	 * Dont ignore the collission when the player has exited the trigger
	 */
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name == "Player") {
			Physics2D.IgnoreCollision (platformCollider, playerCollider, false);
		}
	}
}
