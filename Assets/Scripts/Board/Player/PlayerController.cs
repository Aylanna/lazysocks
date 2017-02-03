using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * This class is a model class for a player
 * 
 * @author Annkatrin Harms
 */
public class PlayerController : MonoBehaviour {

	private int diceValue;
	private int skipAt = -1;
	private int startLifePoints = 1;
	private int lifePoints = 1;

	private int items;
	public string playerName;
	public GameObject startfield;
	private bool healedLeafSection1;
	private bool healedLeafSection2;
	private bool healedLeafSection3;
	private bool bossBattle1;
	private bool bossBattle2;
	private bool bossBattle3;
	private bool isGameWon;
	private bool isExtraLife;
	private bool isDying;

	public int  DiceValue {
		get{ return  diceValue; }
		set{  diceValue = value; }
	}

	public int  Items {
		get{ return  items; }
		set{  items = value; }
	}

	public bool  IsGameWon {
		get{ return  isGameWon; }
		set{  isGameWon = value; }
	}

	public bool IsDying {
		get{ return isDying; }
		set{ isDying = value; }
	}

	public bool IsExtraLife {
		get{ return isExtraLife; }
		set{ isExtraLife = value; }
	}
	public bool BossBattle1 {
		get{ return bossBattle1; }
		set{ bossBattle1 = value; }
	}

	public bool BossBattle2 {
		get{ return bossBattle2; }
		set{ bossBattle2 = value; }
	}

	public bool BossBattle3 {
		get{ return bossBattle3; }
		set{ bossBattle3 = value; }
	}

	public void SetHealedLeafSection1() {
		if (items == 1)
			this.healedLeafSection1 = true;
		else
			this.healedLeafSection1 = false;
	}

	public bool IsHealedLeafSection1() {
		return healedLeafSection1;
	}

	public void SetHealedLeafSection2() {
		if (items == 2)
			this.healedLeafSection2 = true;
		else
			this.healedLeafSection2 = false;
	}

	public bool IsHealedLeafSection2() {
		return healedLeafSection2;
	}

	public void SetHealedLeafSection3() {
		if (items == 3)
			this.healedLeafSection3 = true;
		else
			this.healedLeafSection3 = false;
	}

	public bool IsHealedLeafSection3() {
		return healedLeafSection3;
	}

	public int SkipAt {
		get{ return skipAt; }
		set{ skipAt = value; }
	}

	public int StartLifePoints{
		get{ return startLifePoints; }
		set{ startLifePoints = value; }
	}
	public int LifePoints {
		get{ return lifePoints; }
		set{ lifePoints = value; }
	}
		
	public void AddLifePoints() {
		this.lifePoints++;
	}

	public void ReduceLifePoints() {
		this.lifePoints--;
		if (lifePoints <= 0) {
			isDying = true;
			lifePoints = 1;
		}
	}

	public bool IsPlayerInBossBattleState() {
		if (bossBattle1) {
			return true;
		} else {
			if (bossBattle2) {
				return true;
			} else {
				if (bossBattle3) {
					return true;
				} else {
					return false;
				}
			}
		}
	}
		
}
