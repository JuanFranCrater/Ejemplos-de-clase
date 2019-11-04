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
    private Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (_canShoot && (Input.GetAxis(fireAxis) > 0))
        {

            _anim.SetBool("shoot", true);
            Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
            _canShoot = false;
            _shootTimer += 1 / fireSpeed;
        }
        else
        {
            if(Input.GetAxis(fireAxis) <= 0)
            _anim.SetBool("shoot", false);
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
  
}
