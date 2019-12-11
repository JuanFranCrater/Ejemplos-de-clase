using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1.0f;
    Animator anim;
    AudioSource audioSource;
    private bool canMove =true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            anim.SetTrigger("Attack");
            desactivarMovimiento();
            Invoke("SonidoEspada", 0.9f);
            Invoke("activarMovimiento", 2.2f);

        }
        else
        {
            if (canMove)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(new Vector3(0, 0, 0.03f));

                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(new Vector3(0, 0, -0.03f));
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Rotate(new Vector3(0, 1f, 0));
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Rotate(new Vector3(0, -1f, 0));
                }
                anim.SetBool("Run", Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow));
            }
        }
    }
    public void activarMovimiento()
    {
        canMove = true;
    }
    public void desactivarMovimiento()
    {
        canMove = false;
    }
    public void SonidoEspada()
    {
        audioSource.pitch = Random.Range(0.7f, 1.3f);
            audioSource.Play();
    }
}
