using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class Hole : MonoBehaviour
{
    [SerializeField] public GameObject mole;

    private GameObject g;

    //mole entity todo make different sorts of moles
    public int aliveTime = 1;
    public int scoreValue = 10;

    //timer
    private float time;
    private float spawnTime;

    // Spawn Interval
    private int intervalMin = 5;
    private int intervalMax = 15;

    private void Start()
    {
        setRandomTime();
    }


    private void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {

            Spawn();
            setRandomTime();

        }
        DestroyOnTouch();
    }

    //Spawn a mole game object in a certain interval
    private void Spawn()
    {
        time = 0;

        //spawn the mole at the hole position
        g = (GameObject) Instantiate(mole, transform.position, transform.rotation);

        //destroy game object after a certain time
        Destroy(g, aliveTime);
    }

    //destroy the game object when player touches a mole
    private void DestroyOnTouch()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("touch detected ");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit " + hit.collider.name);

                if (hit.collider.gameObject.tag == "Mole")
                {
                    Debug.Log("Tag matches");
                    Destroy(g);
                    ScoreManager.score += scoreValue;
                }
            }
        }
    }

    private void setRandomTime()
    {
        spawnTime = Random.Range(intervalMin, intervalMax);
    }
}
