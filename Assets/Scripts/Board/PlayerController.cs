using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private int diceValue;
    public string playerName;

    public void SetDiceValue(int diceValue)
    {
        this.diceValue = diceValue;
    }

    public int GetDiceValue()
    {
        return diceValue;
    }



	

}
