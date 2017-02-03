using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * This class is superclass of all fields
 * 
 * @author Annkatrin Harms
 */
public class BoardField : FieldAct {
	protected Sceneloader scl;
	protected static int bacterialInvadersID = 3;
	protected static int brickBreakerID = 5;
	protected static int donkeyKongID = 6;
	protected static int memoryBossID = 4;
	protected static int tissueRacerID = 2;
	protected static int whackAMoleID = 1;


	void Start() {
		scl = GameObject.Find("Sceneloader").GetComponent<Sceneloader> ();
	}

	public override void DoFieldAction () {
		

	}



}
