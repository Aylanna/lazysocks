using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour {
	
	private GameController gc;
	private bool extraLife;
	private int sceneIndex;
	private bool item;
	private bool loseLifePoint;



	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
	}

	public void UnLoadMinigame () {
		SceneManager.UnloadScene(sceneIndex);
		//SceneManager.UnloadSceneAsync (sceneIndex);
		gc.mainScene.SetActive (true);
		gc.isMinigamePlayed = true;
		if (extraLife) 
			gc.activePlayer.GetComponent<PlayerController> ().AddLifePoints ();
		
		if(loseLifePoint)
			gc.activePlayer.GetComponent<PlayerController> ().ReduceLifePoints ();

				
		if (item)
			gc.activePlayer.GetComponent<PlayerController> ().SetItem (1);
			
	
	}

	public void LoadMinigame() {
		gc.mainScene.SetActive (false);
		StartCoroutine (load());
		//SceneManager.LoadScene (sceneIndex, LoadSceneMode.Additive);

		//SceneManager.LoadScene (sceneIndex);
		//SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
	}

	protected IEnumerator load() {
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneIndex,LoadSceneMode.Additive);
		//async.allowSceneActivation = ;
		yield return async;
	}

	public void SetExtraLife(bool extraLife) {
		this.extraLife = extraLife;
	}

	public void SetLoseLifePoint(bool loseLifePoint) {
		this.loseLifePoint = loseLifePoint;
	}

	public void SetItem(bool item) {
		this.item = item;
	}

	public void SetSceneIndex(int sceneIndex) {
		this.sceneIndex = sceneIndex;
	}
}
