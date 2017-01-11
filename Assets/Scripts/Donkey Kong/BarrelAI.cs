﻿using UnityEngine;
using System.Collections;

public class BarrelAI : MonoBehaviour {

	[SerializeField] private float force; 

	private Collider2D currentFloor;
	private float timeUntilFallDown = int.MaxValue;
	private int dir;

	void Start() {
		dir = 1;
	}

	void OnCollisionEnter2D(Collision2D collision) {

		if (collision.collider.gameObject.name == "InvisibleWallLeft") {
			dir = 1;
		}
		else if (collision.collider.gameObject.name == "InvisibleWallRight") {
			dir = -1;
		}
		else if (collision.collider.gameObject.name.Contains("Floor")) {
			currentFloor = collision.collider;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(force*dir, 0.0f));
		}
	}

	void FixedUpdate() {

		if (timeUntilFallDown != int.MaxValue) 
			timeUntilFallDown -= Time.fixedDeltaTime;

		if (timeUntilFallDown <= 0) {
			FallDown();
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		
		if (otherCollider.gameObject.name == "BarrelRemovalArea") {
			Destroy(gameObject);
		}
		else if (otherCollider.gameObject.name == "Ladder" && Random.Range(0, 10) > 7) {

			if (otherCollider.transform.position.y < transform.position.y) {
				timeUntilFallDown = 0.09f; // Fall down the ladder after 0.09 seconds
			}
		}
	}

	void FallDown() {

		Physics2D.IgnoreCollision(currentFloor, gameObject.GetComponent<Collider2D>()); // Ignore collisions between the current floor and the barrel (so that it can fall through)
		GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
		currentFloor = null;
		timeUntilFallDown = int.MaxValue;
		dir *= -1;
	}
}