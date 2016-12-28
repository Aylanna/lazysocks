using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour {
	
	private GameController gc;
	private bool loadMinigame;
	private int sceneIndex;



	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
	}

	public void UnLoadMinigame () {
	    SceneManager.UnloadScene(sceneIndex);
		gc.mainScene.SetActive (true);
		gc.isMinigamePlayed = true;
	
	}

	public void LoadMinigame() {
		gc.mainScene.SetActive (false);
		SceneManager.LoadScene (sceneIndex, LoadSceneMode.Additive);
	}

	public void SetLoadMinigame(bool loadMinigame) {
		this.loadMinigame = loadMinigame;
	}

	public void SetSceneIndex(int sceneIndex) {
		this.sceneIndex = sceneIndex;
	}
}
