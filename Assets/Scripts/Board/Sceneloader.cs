using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour {
	
	private GameController gc;
	private bool extraLife;
	private int sceneIndex;
	private bool item;
	private bool loseLifePoint;
	private bool playedBossBattle;



	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
	}

	public void UnLoadMinigame () {
		SceneManager.UnloadScene(sceneIndex);
		gc.mainScene.SetActive (true);
		StartCoroutine (Waiting ());
		ManageMinigameOptions ();

	}

	void ManageMinigameOptions() {
		if (extraLife && !playedBossBattle) 
			gc.activePlayer.GetComponent<PlayerController> ().AddLifePoints ();
		if (loseLifePoint && playedBossBattle) {
			gc.activePlayer.GetComponent<PlayerController> ().ReduceLifePoints ();
		}
		if (item && playedBossBattle) {
			gc.activePlayer.GetComponent<PlayerController> ().SetItem ();
			gc.activePlayer.GetComponent<PlayerController> ().SetHealedLeafSection1 ();
			gc.activePlayer.GetComponent<PlayerController> ().SetHealedLeafSection2 ();
			gc.activePlayer.GetComponent<PlayerController> ().SetHealedLeafSection3();
			SetBossBattleStateFalse ();
			playedBossBattle = false;
		} else {
			if (!item && playedBossBattle) {
				playedBossBattle = false;
				SetBossBattleStateTrue ();
			}
		}
	}

	protected IEnumerator Waiting()
	{
		yield return new WaitForSeconds(2.0f);
		gc.isMinigamePlayed = true;

	}

	public void SetBossBattleStateFalse() {
		if (gc.activePlayer.GetComponent<PlayerController> ().GetItem () == 1)
			gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle1 (false);
		if (gc.activePlayer.GetComponent<PlayerController> ().GetItem () == 2)
			gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle2 (false);
		if (gc.activePlayer.GetComponent<PlayerController> ().GetItem () == 3)
			gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle3 (false);
	}

	public void SetBossBattleStateTrue() {
		if (gc.activePlayer.GetComponent<PlayerController> ().GetItem () == 0)
			gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle1 (true);
		if (gc.activePlayer.GetComponent<PlayerController> ().GetItem () == 1)
			gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle2 (true);
		if (gc.activePlayer.GetComponent<PlayerController> ().GetItem () == 3)
			gc.activePlayer.GetComponent<PlayerController> ().SetBossBattle3 (true);
	}

	public void LoadMinigame() {
		gc.mainScene.SetActive (false);
		StartCoroutine (load());
	}

	protected IEnumerator load() {
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneIndex,LoadSceneMode.Additive);
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

	public void SetPlayedBossBattle(bool playedBossBattle) {
		this.playedBossBattle = playedBossBattle;
	}
}
