using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float radius;
    public LayerMask enemyMask;
    public int damage;

    private void Awake()
    {
        enabled = false;
    }
    private void Update()
    {
        OnDrawGizmos();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void Boom()
    {
        Collider[] objs = Physics.OverlapSphere(transform.position, radius, enemyMask);
        foreach (Collider c in objs)
        { }
           // c.GetComponent<Health>().TakeDamage(damage);
    }

}
