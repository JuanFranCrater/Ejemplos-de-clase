using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAdder : MonoBehaviour
{

    public void addPoints(int points)
    {
        GameControl.instance.addScore(points);
    }
}
