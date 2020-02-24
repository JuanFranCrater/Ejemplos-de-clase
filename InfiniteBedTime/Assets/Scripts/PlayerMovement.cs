using System;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speedMovement;
    public int  maxXPos;
    public int  minXPos;

    private Vector3 targetPos;

    public int health;

    public GameObject moveEffect;
    public GameObject restart;
    public GameObject collisionEffect;

    public Animator camAnimator;

    public TextMeshProUGUI healthText;

    public AudioSource auch;
    public AudioSource move;

    private bool up = false;
    private bool down = false;

    void FixedUpdate()
    {
       
        if (health <= 0)
        {
           restart.SetActive(true);
            Time.timeScale = 0;
           Destroy(gameObject);
        }
        healthText.text = health.ToString();

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speedMovement * Time.deltaTime);
        getInputs();
        GameObject particle;
        if (up)
        {
            particle = Instantiate(moveEffect, transform.position, Quaternion.identity);
            Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
            targetPos = new Vector3(getPosition(1), transform.position.y ,transform.position.z);
            move.pitch = (UnityEngine.Random.Range(0.6f, .9f));
            move.Play();
        }
        if (down)
        {
            particle = Instantiate(moveEffect, transform.position, Quaternion.identity);
            Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
            targetPos = new Vector3(getPosition(-1), transform.position.y, transform.position.z);
            move.pitch = (UnityEngine.Random.Range(0.6f, .9f));
            move.Play();
        }
       
    }

    private void getInputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.x < maxXPos)
        {
            up = true;
        }
        else
        {
            up = false;    
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.x > minXPos)
        {
            down = true;
        }
        else
        {
            down = false;
        }
        if (up && down)
        {
            up = false;
            down = false;
        }
        }

    private float getPosition(int v)
    {
            switch ((int)transform.position.x)
            {
                case 0:
                 return v == 1 ?maxXPos:minXPos;
                case 3:
                 return v == 1 ?maxXPos:0;
                case -3:
                 return v == 1 ?0:minXPos;
                default:
                 return 0;
            }
    }

    public void takeHealth()
    {
       health--;
       camAnimator.SetTrigger("shake");
       GameObject particle = Instantiate(collisionEffect, transform.position, Quaternion.identity);
       Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
       auch.pitch = (UnityEngine.Random.Range(0.6f, .9f));
       auch.Play();
    }
}
