using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float BulletSpeed;
	public float LifeTime;
	public int damage;
	public LayerMask layermask;

	void Start()
	{
		Destroy (gameObject, LifeTime);
	}

	void Update () 
	{
		transform.Translate (transform.right * BulletSpeed * Time.deltaTime,Space.World);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (layermask == (layermask | (1 << col.gameObject.layer)))
		{
			if(col.GetComponent<Health>() != null)
			{
				col.GetComponent<Health>().TakeDamage(damage);
			}
			Destroy(gameObject);
		}
	}
}
