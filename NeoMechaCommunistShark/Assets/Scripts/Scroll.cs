using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Rigidbody2D cuerpo;

    void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
        cuerpo.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
    }

    void FixedUpdate()
    {    
        if (GameControl.instance.gameOver == true)
        {
            cuerpo.velocity = Vector2.zero;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
   
}
