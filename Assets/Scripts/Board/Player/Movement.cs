using UnityEngine;
using System.Collections;

/**
 * This class manages the player movement on the board.
 * 
 * @author Annkatrin Harms
 */
public class Movement : MonoBehaviour {

	public EditorPath pathToFollow;
	public int currentWayPointID = 0;
	public float speed;
	public float rotationSpeed = 5.0f;
	public string pathName;
	private bool move;
	private GameObject currentField;
	private static int bossBattle1 = 11;
	private static int bossBattle2 = 31;
	private static int bossBattle3 = 51;

	void Update() {
		if (!move)
			return;
		CheckBossBattle ();
		Move ();
		
	}

	/**
	 * Player lost all lifes and need to start at the startfield again.
	 * Means the boss battle states are set to false.
	 */
	public void ProcessDying (){
		GameController.Instance.gameMenu.GetComponent<GameMenu> ().SwitchGameMessage (7);
		gameObject.GetComponent<PlayerController> ().IsDying = false;
		currentWayPointID = 0;
		transform.position = pathToFollow.pathObjs [currentWayPointID].position;
		gameObject.GetComponent<PlayerController> ().BossBattle1 = false;
		gameObject.GetComponent<PlayerController> ().BossBattle2 = false;
		gameObject.GetComponent<PlayerController> ().BossBattle3 = false;
		gameObject.GetComponent<PlayerController> ().Items = 0;
		gameObject.GetComponent<PlayerController> ().SetHealedLeafSection1 ();
		gameObject.GetComponent<PlayerController> ().SetHealedLeafSection2 ();
		gameObject.GetComponent<PlayerController> ().SetHealedLeafSection3 ();
	}
		
	/**
	 * If player the player is on boss battle field and lost it the current way point is set again to the boss battle field.
	 */
	void CheckBossBattle() {
		if (currentWayPointID >= bossBattle1
			&& !gameObject.GetComponent<PlayerController> ().BossBattle1 && gameObject.GetComponent<PlayerController> ().Items == 0)
			currentWayPointID = bossBattle1;
		
		if (currentWayPointID >= bossBattle2
		    && !gameObject.GetComponent<PlayerController> ().BossBattle2 && gameObject.GetComponent<PlayerController> ().Items == 1) 
			currentWayPointID = bossBattle2;
		
		if (currentWayPointID >= bossBattle3
			&& !gameObject.GetComponent<PlayerController> ().BossBattle3 && gameObject.GetComponent<PlayerController> ().Items == 2) 
			currentWayPointID = bossBattle3;
	}

	/**
	 * If the actual position of the player is different as the current way point, then the player
	 * moves to the current way point.
	 * Otherwise the movement is set to false and the current field is set.
	 */
	void Move() {
		if (transform.position != pathToFollow.pathObjs [currentWayPointID].position) {
			transform.position = Vector3.Lerp (transform.position, pathToFollow.pathObjs [currentWayPointID].position, Time.deltaTime * speed);
		} else {
			currentField = pathToFollow.pathObjs [currentWayPointID].gameObject;
			move = false;
		}
	}

	//Getter and Setter
	public GameObject GetCurrentField() {
		return currentField;
	}

	public void SetMove(bool move) {
		this.move = move;
	}

	public bool GetMove() {
		return move;
	}

}
