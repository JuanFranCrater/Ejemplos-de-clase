using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    public float fireSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletStart;
    private bool _canShoot = true;
    private float _shootTimer;
    public string fireAxis;
    // Update is called once per frame
    void Update()
    {
        if (_canShoot && (Input.GetAxis(fireAxis) > 0))
        {
            Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
            _canShoot = false;
            _shootTimer += 1 / fireSpeed;
        }
        if (!_canShoot)
        {
            _shootTimer -= Time.deltaTime;
            if (_shootTimer <= 0)
            {
                _canShoot = true;
            }
        }
    }
    void upgradedGun(int typeGun)
    {
        switch (typeGun)
        {
            default:
                fireSpeed = fireSpeed * 2;
                break;
        }
    }
}
