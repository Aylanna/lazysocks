using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {

	public Canvas start;
	public Canvas numbersOfPlayer;


	void Start() {

		numbersOfPlayer.enabled = false;
	}
	public void StartGame() {
		start.enabled = false;
		numbersOfPlayer.enabled = true;

	}

	public void GameRules() {

		//TODO
	}
}
