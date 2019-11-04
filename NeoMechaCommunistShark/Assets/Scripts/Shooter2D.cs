﻿using UnityEngine;
using System.Collections;

public class Shooter2D : MonoBehaviour 
{
	public float fireSpeed = 5f;
	public GameObject bulletPrefab;
    public Transform bulletStart;
	private bool _canShoot = true;
	private float _shootTimer;
    public string fireAxis;

	[Header ("IA")]
	public bool hasIA;

	void FixedUpdate()
	{
		if(hasIA)
		{
			CheckIA();
		}
		else
		{
			CheckFire();
		}
	}

	private void CheckFire()
	{
		if(_canShoot && (Input.GetAxis(fireAxis) > 0))
		{
			Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
			_canShoot = false;
			_shootTimer += 1/fireSpeed;
		}
		if(!_canShoot)
		{
			_shootTimer -= Time.deltaTime;
			if(_shootTimer<=0)
			{
				_canShoot = true;
			}
		}
	}

	private void CheckIA()
	{
		if(_canShoot)
		{
			Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
			_canShoot = false;
			_shootTimer += 1/fireSpeed;
		}
		if(!_canShoot)
		{
			_shootTimer -= Time.deltaTime;
			if(_shootTimer<=0)
			{
				_canShoot = true;
			}
		}
	}
}
