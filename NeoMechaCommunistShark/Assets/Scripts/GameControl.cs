using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;            

    private int score = 0;                        
    public bool gameOver = false;                
    public float scrollSpeed = -1.5f;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    public void pausar()
    { 

    }

    internal void addScore(int puntos)
    {
        score = score + puntos;
    }
}
