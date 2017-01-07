using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

	public Rigidbody2D rb;
	public float ballForce;
	bool gameStarted = false;

	public UiManagerBrickBreaker ui; 

	// Update is called once per frame
	void Update () {
		StartGameKey (); 
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Finish")
		{
			Debug.Log ("Game Over");
			Destroy (gameObject);

			ui.GameOver (); 
		}
	}

	public void StartGameKey () {
		if ((Input.GetKeyUp (KeyCode.Space) && gameStarted == false) || (Input.touchCount > 0 && gameStarted == false) ) {
			transform.SetParent(null);
			rb.isKinematic = false;
			rb.AddForce (new Vector2 (ballForce, ballForce));
			gameStarted = true;
		}
	}
}
