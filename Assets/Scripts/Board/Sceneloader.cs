using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour {
	
	private GameController gc;
	private bool extraLife;
	private int sceneIndex;



	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
	}

	public void UnLoadMinigame () {
	    SceneManager.UnloadScene(sceneIndex);
		gc.mainScene.SetActive (true);
		gc.isMinigamePlayed = true;
		if(extraLife)
			gc.activePlayer.GetComponent<PlayerController> ().AddLifePoints ();
	
	}

	public void LoadMinigame() {
		gc.mainScene.SetActive (false);
		SceneManager.LoadScene (sceneIndex, LoadSceneMode.Additive);
	}

	public void SetExtraLife(bool extraLife) {
		this.extraLife = extraLife;
	}

	public void SetSceneIndex(int sceneIndex) {
		this.sceneIndex = sceneIndex;
	}
}
