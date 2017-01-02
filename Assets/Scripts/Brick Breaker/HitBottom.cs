using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBottom : MonoBehaviour {

    GameObject ballObject; 

	// Use this for initialization
	void Start () {
		ballObject = GameObject.FindGameObjectWithTag ("Ball"); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Ball")
        {
			Debug.Log ("Game Over :)"); 
			Destroy(ballObject);
        }
    }
}
