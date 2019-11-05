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
        if (Input.GetMouseButtonUp(1)&& GameControl.instance.hasBoom)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Baddies").Length; i++)
                GameObject.FindGameObjectsWithTag("Baddies")[i].GetComponent<Health>().Die(); ;
            GameControl.instance.hasBoom = false;
        }

        if (_canShoot && (Input.GetAxis(fireAxis) > 0))
        {
            float y = bulletStart.position.y;
            float x = bulletStart.position.x;
            _anim.SetBool("shoot", true);
            if (GameControl.instance.hasTriple)
            {
                
                Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
                Instantiate(bulletPrefab, new Vector3(x,y+0.6f), bulletStart.rotation);
                Instantiate(bulletPrefab, new Vector3(x, y - 0.6f), bulletStart.rotation);
            }
            else
            {
                Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
            }
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
