﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<CoinsCollector>())
        {
            other.GetComponent<CoinsCollector>().AddCoins(value);
            Destroy(gameObject);
        }
    }
}
