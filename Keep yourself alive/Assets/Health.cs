using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    float health = 1;
    public Image vidaImg;
    public GameManager gameManager;

    void FixedUpdate()
    {
        vidaImg.fillAmount = health;
        if (health <= 0)
        {
            gameManager.finJuego();
        }
    }
    public void hacerDanio()
    {
        health -= 0.0001f;
    }
}
