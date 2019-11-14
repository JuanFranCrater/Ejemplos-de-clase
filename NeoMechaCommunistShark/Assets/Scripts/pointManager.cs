using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointManager : MonoBehaviour
{
    private int points;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void setPoints(int score)
    {
        points = score;
    }

    public int getPoints()
    {
        return points;
    }
}
