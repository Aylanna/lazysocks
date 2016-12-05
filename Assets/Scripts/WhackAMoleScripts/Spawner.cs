using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Spawner : MonoBehaviour
{
    public GameObject good;
    public GameObject bad;

    public Vector3[] spawnPoints;
    public bool[] taken;


    private bool startTimer;
    private float timeLeft;

    public static int spawnNum;
    public static float timer;
    private int takenCounter;
    public static string playName;
    public static float removeTimer;

    public static bool isTapped = true;
    public static bool check = false;

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
	        if (!isTapped)
	        {
	            //SceneManager.LoadScene("GameOver");
	        }

	        if (check)
	        {
	            Debug.Log("Check == true!");
	            if (playName == "Good")
	            {
	                Score.score++;
	            }
	            if (playName == "Bad")
	            {
	                Score.score--;
	            }
	            if (Score.score < 0)
	            {
	                StartCoroutine(PauseBeforeGameOver());
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

    private void ResetValues()
    {
        timeLeft = 2.0f;
        startTimer = true;
        isTapped = true;
        check = false;
        timer = 1f;
        spawnNum = 0;
        Score.score = 0;
        takenCounter = 0;
        removeTimer = 1.5f;
    }

    protected IEnumerator PauseBeforeNewCharacter()
    {
        yield return new WaitForSeconds(0.2f);

        SpawnCharacter();
    }

    protected IEnumerator PauseBeforeGameOver()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("KEEEEEEEEEEEEEK GAME OVER");
        //SceneManager.LoadScene("GameOver");
    }

    private void InitializeSpawnPositions()
    {
        spawnPoints = new Vector3[9];
        taken = new bool[9];

        float z = -1.3f;

        // Top row
        spawnPoints[0] = new Vector3(-1.97f, 2.7f, z);
        spawnPoints[1] = new Vector3(0.1f, 2.7f, z);
        spawnPoints[2] = new Vector3(2.1f, 2.7f, z);

        //Middle row
        spawnPoints[3] = new Vector3(-1.97f, -0.42f, z);
        spawnPoints[4] = new Vector3(0.1f, -0.42f, z);
        spawnPoints[5] = new Vector3(2.1f, -0.42f, z);

        //Bottom row
        spawnPoints[6] = new Vector3(-1.97f, -3.49f, z);
        spawnPoints[7] = new Vector3(0.1f, -3.49f, z);
        spawnPoints[8] = new Vector3(2.1f, -3.49f, z);
    }

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
                    Instantiate(good, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 1)
                {
                    Instantiate(bad, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 2)
                {
                    Instantiate(good, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 3)
                {
                    Instantiate(bad, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 4)
                {
                    Instantiate(good, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 5)
                {
                    Instantiate(bad, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 6)
                {
                    Instantiate(good, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 7)
                {
                    Instantiate(bad, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }
                if (spawnType == 8)
                {
                    Instantiate(good, spawnPoints[spawnPoint], Quaternion.Euler(90, 180, 0));
                    taken[spawnPoint] = true;
                }

                takenCounter++;
                spawnNum++;
            }
        }
    }
}
