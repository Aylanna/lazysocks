using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class GameMenu : MonoBehaviour {
	
	private GameController gc;
	public Text lifePointText;
	public Image img;
	public Text gameMessage;


	void Start () {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
	}

	public void UpdateView() {
		lifePointText.text = gc.activePlayer.GetComponent<PlayerController> ().GetLifePoints().ToString();
		img.sprite = gc.activePlayer.GetComponentInChildren<SpriteRenderer> ().sprite;
	}

	public void SetFieldEventMessage(string message) {

		gameMessage.text = message;
	}     
}
