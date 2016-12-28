using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private int diceValue;
	private int skipAt = -1;
    public string playerName;
	public int startLifePoints = 1;
	//public Text lifePointsText;
	private int lifePoints = 1;
	public Transform position;

	void Start () {

		lifePoints = PlayerPrefs.GetInt ("StartLifePoints");


	}

    public void SetDiceValue(int diceValue)
    {
        this.diceValue = diceValue;
    }

    public int GetDiceValue()
    {
        return diceValue;
    }

	/**
     * Manage the dying of the character 
     * Must be called over sendMessage
     */
	void Dying()
	{
		lifePoints--; 
		//UpdateView ();
		if (lifePoints <= 0) {

			//transform.position = startposition
			//lifePoints = startlifePoints

		}
		PlayerPrefs.SetInt ("LifePoints", lifePoints);
		//lifePointsText.text = lifePoints.ToString();
	}

	public void AddLifePoints() {
		lifePoints++;
		PlayerPrefs.SetInt ("LifePoints", lifePoints);
		//lifePointsText.text = lifePoints.ToString();
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



	

}
