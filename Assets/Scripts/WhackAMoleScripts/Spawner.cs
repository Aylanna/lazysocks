using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

/// <summary>
/// This class contains various methods to make sure the characters would spawn at certain spawnpoints, within a certain time and
/// includes behavior what happenes when an character is pressed a good one increases the score and a bad one concludes game over.
///
/// @author: Nick Oosterhuis
/// </summary>
public class Spawner : MonoBehaviour
{
     public GameObject good;
     public GameObject bad;

    public Vector3[] spawnPoints;
    public bool[] taken;

    private bool startTimer;
    public static float timeLeft;

    public static int spawnNum;
    public static float timer;

    private int takenCounter;
    public static string playName;
    public static float removeTimer;

    public static bool isTapped = true;
    public static bool check;

	public GameObject parentObject;


    // Use this for initialization
	private void Start () {
	    ResetValues();
	    InitializeSpawnPositions();
	    timer = 1f;
	    spawnNum = 0;
	    takenCounter = 0;
	}
	
	// Update is called once per frame
	private void Update () {

	    if(startTimer)
	    {
	        timeLeft -= Time.deltaTime;

	        if(timeLeft < 0)
	        {
	            startTimer = false;
	        }
	    }

	    if (!startTimer)
	    {
	        if (check)
	        {
	            if (playName == "Good")
	            {
	                Score.score++;
	            }

	            check = false;
	        }

	        if (spawnNum == 0)
	        {
	            if (takenCounter > 3)
	            {
	                taken = new bool[9];
	                takenCounter = 0;
	            }

	            StartCoroutine(PauseBeforeNewCharacter());
	        }
	    }
	}

    /**
    * methods resets the values of the variables
    */
    private void ResetValues()
    {
        timeLeft = 3.0f;
        startTimer = true;
        isTapped = true;
        check = false;
        timer = 1f;
        spawnNum = 0;
        Score.score = 0;
        takenCounter = 0;
        removeTimer = 1.5f;
    }
    /**
     * Pause before spawning a new character (hand or tentacle)
     */
    protected IEnumerator PauseBeforeNewCharacter()
    {
        yield return new WaitForSeconds(0.2f);

        SpawnCharacter();
    }

    /**
     * Init the spawn options on in the scene were the characters will spawn
     */
    private void InitializeSpawnPositions()
    {
        spawnPoints = new Vector3[9];
        taken = new bool[9];

        float z = 0f;

        // Top row
        spawnPoints[0] = new Vector3(-7.3f, 11.3f, z);
        spawnPoints[1] = new Vector3(0f, 11.3f, z);
        spawnPoints[2] = new Vector3(7.4f, 11.3f, z);

        //Middle row
        spawnPoints[3] = new Vector3(-7.3f, 0f, z);
        spawnPoints[4] = new Vector3(0f, 0f, z);
        spawnPoints[5] = new Vector3(7.4f, 0f, z);

        //Bottom row
        spawnPoints[6] = new Vector3(-7.3f, -11.3f, z);
        spawnPoints[7] = new Vector3(0f, -11.3f, z);
        spawnPoints[8] = new Vector3(7.4f, -11.3f, z);
    }

    /**
     * Spawn the characters at the certain spawnpoints
     */
    private void SpawnCharacter()
    {
        int spawnPoint;
        int spawnType;
        int s = 0;

        while(s == spawnNum)
        {
            spawnPoint = Random.Range(0, 10);
            spawnType = Random.Range(0, 8);

            if (!taken[spawnPoint])
            {
                if (spawnType == 0)
                {
					GameObject goodObj = (GameObject) Instantiate(good, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
					goodObj.transform.parent = parentObject.transform;
                    taken[spawnPoint] = true;
                }
                if (spawnType == 1)
                {
					GameObject badObj = (GameObject)Instantiate(bad, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
					badObj.transform.parent = parentObject.transform;
                    taken[spawnPoint] = true;
                }
                if (spawnType == 2)
                {
					GameObject goodObj = (GameObject) Instantiate(good, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
					goodObj.transform.parent = parentObject.transform;
                    taken[spawnPoint] = true;
                }
                if (spawnType == 3)
                {
					GameObject badObj = (GameObject)Instantiate(bad, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
					badObj.transform.parent = parentObject.transform;
                    taken[spawnPoint] = true;
                }
                if (spawnType == 4)
                {
					GameObject goodObj = (GameObject) Instantiate(good, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
					goodObj.transform.parent = parentObject.transform;
                    taken[spawnPoint] = true;
                }
                if (spawnType == 5)
                {
					GameObject badObj = (GameObject)Instantiate(bad, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
					badObj.transform.parent = parentObject.transform;
                    taken[spawnPoint] = true;
                }
                if (spawnType == 6)
                {
					GameObject goodObj = (GameObject) Instantiate(good, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
					goodObj.transform.parent = parentObject.transform;
                    taken[spawnPoint] = true;
                }
                if (spawnType == 7)
                {
					GameObject badObj = (GameObject) Instantiate(bad, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
					badObj.transform.parent = parentObject.transform;
                    taken[spawnPoint] = true;
                }
                if (spawnType == 8)
                {
					GameObject goodObj = (GameObject) Instantiate(good, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
					goodObj.transform.parent = parentObject.transform;
                    taken[spawnPoint] = true;
                }

                takenCounter++;
                spawnNum++;
            }
        }
    }
}
