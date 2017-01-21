using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private int diceValue;
	private int skipAt = -1;
    public string playerName;
	public int startLifePoints = 1;
	public GameObject startfield;
	private int lifePoints = 1;
	//public Transform position;
	private int items;
	private bool bossBattle1;
	private bool bossBattle2;
	private bool bossBattle3;
	private bool wonGame;


    public void SetDiceValue(int diceValue)
    {
        this.diceValue = diceValue;
    }

    public int GetDiceValue()
    {
        return diceValue;
    }

	public void SetBossBattle1(bool won) {
		bossBattle1 = won;
	}

	public void SetBossBattle2(bool won) {
		bossBattle2 = won;
	}

	public void SetBossBattle3(bool won) {
		bossBattle3 = won;
	}

	public bool IsBossBattle1() {
		return bossBattle1;
	}

	public bool IsBossBattle2() {
		return bossBattle2;
	}

	public bool IsBossBattle3() {
		return bossBattle3;
	}

	public void LifePointsManager() {
		int life = Random.Range (1, -2);
		switch (life) {

		case 1: 
			AddLifePoints ();
			break;
		case -1:
			ReduceLifePoints ();
			break;

		}
	}
	public void AddLifePoints() {
		lifePoints++;
	}

	public void ReduceLifePoints() {
		lifePoints--;
		if (lifePoints <= 0) {
			transform.position = startfield.transform.position;
		}
	}

	public int GetLifePoints() {
		return lifePoints;
	}

	public void SetSkipAt(int skipAt) {
		this.skipAt = skipAt;
	}

	public int GetSkipAt() {
		return skipAt;
	}

	public void SetItem() {
		this.items ++;
	}

	public int GetItem() {
		return items;
	}

	public void SetGameWon(bool won) {
		wonGame = won;
	}

	public bool IsGameWon() {
		return wonGame;
	}
}
