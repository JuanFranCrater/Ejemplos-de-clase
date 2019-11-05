using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choque : MonoBehaviour
{
    public LayerMask layermask;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (layermask == (layermask | (1 << col.gameObject.layer)))
        {
            if (col.GetComponent<Health>() != null)
            {
                col.GetComponent<Health>().TakeDamage(1);
                GetComponent<Health>().TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }
}
