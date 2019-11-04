using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
    }

    void Update()
    {    
        if (GameControl.instance.gameOver == true)
        {
            rigidbody.velocity = Vector2.zero;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
   
}
