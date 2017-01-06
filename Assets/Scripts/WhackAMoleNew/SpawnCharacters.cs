using UnityEngine;
using System.Collections;

public class SpawnCharacters : MonoBehaviour {

	public GameObject good;
	public GameObject bad;

	public Vector3[] spawnPoints;
	public bool[] taken;
	public float currentSpawnDelay = 0.1f;
	public GameObject parentObject;


	// Use this for initialization
	private void Start () {
		InitializeSpawnPositions();
		InvokeRepeating ("ResetTakenPoint", 1, 5f);


	}


		

	/**
     * Init the spawn options on in the scene were the characters will spawn
     */
	private void InitializeSpawnPositions()
	{
		spawnPoints = new Vector3[10];
		taken = new bool[10];

		spawnPoints[0] = new Vector3(-0.203f, 0.009f, 0);
		spawnPoints[1] = new Vector3(1.012f, 0.302f, 0);
		spawnPoints[2] = new Vector3(-0.496f, 0.268f, 0);
		spawnPoints[3] = new Vector3(0.207f, -0.219f, 0);
		spawnPoints[4] = new Vector3(-1.131f, -0.32f, 0);
		spawnPoints[5] = new Vector3(0.289f, 0.149f, 0);
		spawnPoints[6] = new Vector3(0.8f, -0.036f, 0);
		spawnPoints[7] = new Vector3(-0.714f, -0.114f, 0);
		spawnPoints[8] = new Vector3(0.568f, -0.444f, 0);
		spawnPoints[9] = new Vector3(-0.283f, -0.42f, 0);
	}

	/**
     * Spawn the characters at the certain spawnpoints
     */
	private void SpawnCharacter()
	{
		int spawnPoint;
		int spawnType;
		spawnPoint = Random.Range(0, 10);
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
