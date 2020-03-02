using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    [Range(1,5)]
    public float shootSpeed = 1;
    public float rangeAttack;
    public Transform bulletStart;

    private GameObject target;
    private float shootTimer;
    
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CheckAttack();
    }

    private void CheckAttack()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }

        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= rangeAttack) // Estamos en rango de ataque
        {
            transform.LookAt(target.transform);
            if (shootTimer <= 0)
            {
                Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
                shootTimer = shootSpeed;
            }
        }
    }
}
