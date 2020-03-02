using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int points;

    void OnDestroy()
    {
        PlayerPoints playerPoints = FindObjectOfType<PlayerPoints>();
        if(playerPoints != null)
        {
            playerPoints.UpdatePoints(points);
        }
    }
}
