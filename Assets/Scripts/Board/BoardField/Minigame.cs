using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Minigame : FieldAct {
	private GameController gc;
	private Sceneloader scl;


	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();

	}
	public override void DoFieldAction () {
		gc.state = 7;
		Debug.Log ("Mini Game");
		scl.SetSceneIndex (1);
		scl.LoadMinigame ();



	}
}
