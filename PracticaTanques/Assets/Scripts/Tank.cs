using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Transform posGiro;
    public Transform direction;
    public float velocity;
    private Rigidbody cuerpo;
    private bool haLlegado =false;

    void Start()
    {
        cuerpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, posGiro.position) > 1 && !haLlegado)
        {
            cuerpo.velocity = new Vector3(velocity, 0, 0);
            transform.LookAt(posGiro);
        }
        else {
            if (!haLlegado)
            {
                transform.LookAt(direction);
                haLlegado = true;
            }
            cuerpo.velocity = Vector3.forward * velocity;
        }
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
