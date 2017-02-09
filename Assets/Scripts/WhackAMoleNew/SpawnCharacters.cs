using UnityEngine;
using System.Collections;

/**
 * This class manage the spawning of the tentacle and dirty hand and destroys them after a time.
 * 
 * @author Annkatrin Harms
 */
public class SpawnCharacters : MonoBehaviour {

	public GameObject good;
	public GameObject bad;
	public Vector3[] spawnPoints;
	public bool[] taken;
	public float currentSpawnDelay = 0.1f;
	public GameObject parentObject;

	private void Start () {
		InitializeSpawnPositions();
		InvokeRepeating ("ResetTakenPoint", 1, 5f);
	}
		
	/**
     * Init the spawn options on in the scene were the characters will spawn
     */
	private void InitializeSpawnPositions() {
		spawnPoints = new Vector3[12];
		taken = new bool[12];

		spawnPoints[0] = new Vector3(-0.29f, 0.5f, 0);
		spawnPoints[1] = new Vector3(0.37f, 0.51f, 0);
		spawnPoints[2] = new Vector3(0.05f, 0.47f, 0);
		spawnPoints[3] = new Vector3(-0.29f, 0.09f, 0);
		spawnPoints[4] = new Vector3(-0.29f, -0.238f, 0);
		spawnPoints[5] = new Vector3(0.37f, 0.07f, 0);
		spawnPoints[6] = new Vector3(0.37f, -0.328f, 0);
		spawnPoints[7] = new Vector3(0.37f, -0.61f, 0);
		spawnPoints[8] = new Vector3(0.04f, 0.05f, 0);
		spawnPoints[9] = new Vector3(-0.283f, -0.64f, 0);
		spawnPoints[10] = new Vector3(0f, -0.71f, 0);
		spawnPoints[11] = new Vector3(0.01f, -0.327f, 0);
	}

	/**
     * Spawn the characters at the certain spawnpoints
     */
	private void SpawnCharacter() {
		int spawnPoint;
		int spawnType;
		spawnPoint = Random.Range(0, 12);
	    spawnType = Random.Range(0, 9); 
		if (!taken [spawnPoint]) {	
			if (spawnType == 0) {
				GameObject obj = (GameObject)Instantiate (bad, spawnPoints [spawnPoint], Quaternion.identity);
				obj.transform.parent = parentObject.transform;
				taken [spawnPoint] = true;
				Destroy (obj, 3.5f);
			}
			if (spawnType == 1) {
				GameObject obj = (GameObject)Instantiate (bad, spawnPoints [spawnPoint], Quaternion.identity);
				obj.transform.parent = parentObject.transform;
				taken [spawnPoint] = true;
				Destroy (obj, 3.5f);
			}
			if (spawnType == 2) {
				GameObject obj = (GameObject)Instantiate (good, spawnPoints [spawnPoint], Quaternion.identity);
				obj.transform.parent = parentObject.transform;
				taken [spawnPoint] = true;
				Destroy (obj, 1.0f);
			}
			if (spawnType == 3) {
				GameObject obj = (GameObject)Instantiate (bad, spawnPoints [spawnPoint], Quaternion.identity);
				obj.transform.parent = parentObject.transform;
				taken [spawnPoint] = true;
				Destroy (obj, 3.5f);
			}
			if (spawnType == 4) {
				GameObject obj = (GameObject)Instantiate (bad, spawnPoints [spawnPoint], Quaternion.identity);
				obj.transform.parent = parentObject.transform;
				taken [spawnPoint] = true;
				Destroy (obj, 3.5f);
			}
			if (spawnType == 5) {
				GameObject badObj = (GameObject)Instantiate (bad, spawnPoints [spawnPoint], Quaternion.identity);
				badObj.transform.parent = parentObject.transform;
				taken [spawnPoint] = true;
				Destroy (badObj, 3.5f);
			}
			if (spawnType == 6) {
				GameObject obj = (GameObject)Instantiate (good, spawnPoints [spawnPoint], Quaternion.identity);
				obj.transform.parent = parentObject.transform;
				taken [spawnPoint] = true;
				Destroy (obj, 1.0f);
			}
			if (spawnType == 7) {
				GameObject obj = (GameObject)Instantiate (bad, spawnPoints [spawnPoint], Quaternion.identity);
				obj.transform.parent = parentObject.transform;
				taken [spawnPoint] = true;
				Destroy (obj, 3.5f);
			}
			if (spawnType == 8) {
				GameObject obj = (GameObject)Instantiate (bad, spawnPoints [spawnPoint], Quaternion.identity);
				obj.transform.parent = parentObject.transform;
				taken [spawnPoint] = true;
				Destroy (obj, 3.5f);
			}
			if (spawnType == 9) {
				GameObject obj = (GameObject)Instantiate (good, spawnPoints [spawnPoint], Quaternion.identity);
				obj.transform.parent = parentObject.transform;
				taken [spawnPoint] = true;
				Destroy (obj, 1.0f);
			}
		}
	}

	public void StartSpawnInterval() {
		InvokeRepeating ("SpawnCharacter", 1, currentSpawnDelay);
	}

	public void StopSpawn() {
		CancelInvoke("SpawnCharacter");
	}

	void ResetTakenPoint() {
		for (int i = 0; i < taken.Length; i++) {
			if (taken [i] == true)
				taken [i] = false;
		}
	}
}
