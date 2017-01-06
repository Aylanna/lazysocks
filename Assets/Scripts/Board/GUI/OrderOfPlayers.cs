using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OrderOfPlayers : MonoBehaviour {

	public Image[] players = new Image[4];
	private GameController gc;
	public Canvas playerOrder;

	void Start () {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();
		SetImageInActive ();
		playerOrder.enabled = false;
	}

	public void ShowOrderOfPlayer() {
		if (gc.orderOfPlayer.Length >= 1) {
			players [0].sprite = gc.orderOfPlayer [0].GetComponentInChildren<SpriteRenderer> ().sprite;
			players [0].enabled = true;
		
		}
		if (gc.orderOfPlayer.Length >= 2) {
			players [1].sprite = gc.orderOfPlayer [1].GetComponentInChildren<SpriteRenderer> ().sprite;
			players [1].enabled = true;

		}
		if (gc.orderOfPlayer.Length >= 3) {
			players [2].sprite = gc.orderOfPlayer [2].GetComponentInChildren<SpriteRenderer> ().sprite;
			players [2].enabled = true;

		}
		if (gc.orderOfPlayer.Length >= 4) {
			players [3].sprite = gc.orderOfPlayer [3].GetComponentInChildren<SpriteRenderer> ().sprite;
			players [3].enabled = true;

		}


	}

	void SetImageInActive() {
		for (int i = 0; i < players.Length; i++) {
			players [i].enabled = false;
		}

	}
	

}
