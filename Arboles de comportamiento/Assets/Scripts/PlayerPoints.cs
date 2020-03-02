using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    public int points;
    public Text pointsText;

    void Start()
    {
        pointsText.text = points.ToString();
    }

    public void UpdatePoints(int amount)
    {
        points += amount;
        if(pointsText != null)
        {
            pointsText.text = points.ToString();
        }
    }
}
