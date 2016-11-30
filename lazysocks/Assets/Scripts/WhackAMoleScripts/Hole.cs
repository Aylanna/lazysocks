using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class Hole : MonoBehaviour
{
    private GameObject mole;
    private int scoreValue = 10;

    // Spawn Interval
    private int intervalMin = 5;
    private int intervalMax = 15;

    // Use this for initialization
    void Start () {
        Invoke("Spawn", Random.Range(intervalMin, intervalMax));
    }

    //Spawn a mole game object in a certain interval
    void Spawn() {

        GameObject g = (GameObject)Instantiate(mole, transform.position, transform.rotation);
        //g.GetComponent<Mole>(). = Random.Range(10,200);






        Invoke("Spawn", Random.Range(intervalMin, intervalMax));


    }
}
