﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public EditorPath pathToFollow;
	public int currentWayPointID = 0;
	public float speed;
	private float reachDistance = 1.0f; // Distance from pivot to waypoint to make it smooth
	public float rotationSpeed = 5.0f;
	public string pathName;
	private bool move;

	void Start() {
	//	pathToFollow = GameObject.Find (pathName).GetComponent<EditorPath>();

	}

	void Update() {
		if (!move)
			return;
		if (transform.position != pathToFollow.pathObjs [currentWayPointID].position) {
			transform.position = Vector3.Lerp (transform.position, pathToFollow.pathObjs [currentWayPointID].position, Time.deltaTime * speed);
		} else {
			//currentWayPointID++;
			move = false;
		}
	}

	public void SetMove(bool move) {
		this.move = move;
	}

}
