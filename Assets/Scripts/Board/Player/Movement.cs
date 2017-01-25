using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public EditorPath pathToFollow;
	public int currentWayPointID = 0;
	public float speed;
	private float reachDistance = 1.0f; // Distance from pivot to waypoint to make it smooth
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
		CheckForGoal ();
		CheckBossBattle ();
		//CheckIsDead ();
		Move ();
		
	}

	public void CheckIsDead (){
			gameObject.GetComponent<PlayerController> ().SetDying (false);
			currentWayPointID = 0;
			transform.position = pathToFollow.pathObjs [currentWayPointID].position;
	}

	void CheckForGoal() {
		if (currentWayPointID >= pathToFollow.pathObjs.Count) {
			currentWayPointID = pathToFollow.pathObjs.Count - 1;
			gameObject.GetComponent<PlayerController> ().SetGameWon (true);
		}
	}

	void CheckBossBattle() {
		if (currentWayPointID >= bossBattle1
			&& !gameObject.GetComponent<PlayerController> ().IsBossBattle1 () && gameObject.GetComponent<PlayerController> ().GetItem() == 0)
			currentWayPointID = bossBattle1;
		
		if (currentWayPointID >= bossBattle2
		    && !gameObject.GetComponent<PlayerController> ().IsBossBattle2 () && gameObject.GetComponent<PlayerController> ().GetItem () == 1) {
			currentWayPointID = bossBattle2;

		}

		if (currentWayPointID >= bossBattle3
			&& !gameObject.GetComponent<PlayerController> ().IsBossBattle3 () && gameObject.GetComponent<PlayerController> ().GetItem() == 2)
			currentWayPointID = bossBattle3;
	}

	void Move() {
		if (transform.position != pathToFollow.pathObjs [currentWayPointID].position) {
			transform.position = Vector3.Lerp (transform.position, pathToFollow.pathObjs [currentWayPointID].position, Time.deltaTime * speed);
		} else {
			currentField = pathToFollow.pathObjs [currentWayPointID].gameObject;
			move = false;
		}
	}

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
