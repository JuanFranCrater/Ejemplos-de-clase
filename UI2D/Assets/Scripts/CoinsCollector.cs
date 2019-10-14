using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollector : MonoBehaviour
{
    public int points;
    public Text pointsText;

    void Start()
    {
        if(pointsText)
            pointsText.text = "x " + points;
    }

    public void AddCoins(int amount)
    {
        points += amount;

        if(pointsText)
            pointsText.text = "x " + points;
    }
}
