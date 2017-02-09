using UnityEngine;
using System.Collections;

public class LadderController : MonoBehaviour {

	private PlayerControl thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("Player").GetComponent<PlayerControl> (); 
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Player") {
			thePlayer.onLadder = true; 
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.name == "Player") {
			thePlayer.onLadder = false; 
		}
	}


}
