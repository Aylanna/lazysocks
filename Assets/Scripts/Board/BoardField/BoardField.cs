using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BoardField : FieldAct {
	protected GameController gc;
	protected Sceneloader scl;
	protected static int bacterialInvadersID = 3;
	protected static int brickBreakerID = 5;
	protected static int donkeyKongID = 6;
	protected static int memoryBossID = 4;
	protected static int tissueRacerID = 2;
	protected static int whackAMoleID = 1;


	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();

	}

	public override void DoFieldAction () {
		

	}



}
