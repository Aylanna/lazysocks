using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * This class manages the loading of a minigame or bossbattle. Also the result of each game.
 * 
 * @author Annkatrin Harms
 */
public class Sceneloader : MonoBehaviour {
	
	private GameController gc;
	private bool extraLife;
	private bool item;
	private bool loseLifePoint;
	private bool playedBossBattle;
	private int sceneIndex;

	void Start() {
		//gc = GameObject.Find("GameController").GetComponent<GameController> ();
	}

	/**
	 * Unload the additve scene, set main scene active again
	 * and manages the result options for minigames.
	 */
	public void UnLoadMinigame () {
		SceneManager.UnloadScene(sceneIndex);
		GameController.Instance.mainScene.SetActive (true);
		ManageMinigameOptions ();
		StartCoroutine (Waiting ());

	}

	/**
	 * If a player plays a minigame and win the game, he will get an extra life.
	 * If a player played a bossbattle and won it, he will get an item and bossbattle state will set to false. 
	 * Also the dead flower of this section will set to healed.
	 * If a player played a bossbattle and lost it, he will lose a life and bossbattle state will set to true.
	 */
	void ManageMinigameOptions() {
		if (extraLife && !playedBossBattle) 
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().AddLifePoints ();
		if (loseLifePoint && playedBossBattle) {
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().ReduceLifePoints ();
		}
		if (item && playedBossBattle) {
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().Items += 1;
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().SetHealedLeafSection1();
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().SetHealedLeafSection2();
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().SetHealedLeafSection3 ();
			SetBossBattleStateFalse ();
			playedBossBattle = false;
		} else {
			if (!item && playedBossBattle) {
				playedBossBattle = false;
				SetBossBattleStateTrue ();
			}
		}
		if (GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().Items == 3)
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().IsGameWon = true;
	}

	/**
	 * waiting for to set minigame played true in the GameController.
	 */
	protected IEnumerator Waiting(){
		yield return new WaitForSeconds(2.0f);
		GameController.Instance.IsMinigamePlayed = true;
	}
		
	/**
	 * Bossbattle state for a special section on board is set to false.
	 * This depends on how many items a player already won.
	 */
	public void SetBossBattleStateFalse() {
		if (GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().Items == 1)
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().BossBattle1 = false;
		if (GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().Items == 2)
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().BossBattle2 = false;
		if (GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().Items == 3)
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().BossBattle3 = false;
	}

	/**
	 * Bossbattle state for a special section on board is set to true.
	 * This depends on how many items a player already won.
	 */
	public void SetBossBattleStateTrue() {
		if (GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().Items == 0)
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().BossBattle1 = true;
		if (GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().Items == 1)
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().BossBattle2 = true;
		if (GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().Items == 2)
			GameController.Instance.ActivePlayer.GetComponent<PlayerController> ().BossBattle3 = true;
	}

	/**
	 * Each minigame or boss battle is load in an additive scene modus
	 */
	public void LoadMinigame() {
		GameController.Instance.mainScene.SetActive (false);
		StartCoroutine (load());
	}

	/**
	 * Waiting until additive scene is completely loaded. 
	 */
	protected IEnumerator load() {
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneIndex,LoadSceneMode.Additive);
		yield return async;
	}

	// Setter methode for mingame result options

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
