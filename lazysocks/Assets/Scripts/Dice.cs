using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    private int index;
    public Sprite[] sprites = new Sprite[6];
    public Canvas rollADice;
    private Button dice;

    void Start()
    {
        dice = rollADice.GetComponent<Canvas>().GetComponentInChildren<Button>();
    }
    public void RollDice()
    {
        index = Random.Range(1, 7);
        
    }
}
