using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public GameObject particleEffect;

    void FixedUpdate()
    {
        transform.position += new Vector3(0.0f, 0.0f, speed) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().takeHealth();
            Destroy(gameObject);
        }
        else
        {
            GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
