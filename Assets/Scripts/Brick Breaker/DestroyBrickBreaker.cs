using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrickBreaker : MonoBehaviour {

	public GameObject additiveScene;
	private Sceneloader scl;
	public UiManagerBrickBreaker ui;



	void Start() {
		
	}
	public void DestroyScene() {
		//ui = GameObject.Find ("UiManager").GetComponent<UiManagerBrickBreaker> ();
		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();
		scl.SetExtraLife(true);
		scl.UnLoadMinigame ();
		Destroy (additiveScene);
	}
}
