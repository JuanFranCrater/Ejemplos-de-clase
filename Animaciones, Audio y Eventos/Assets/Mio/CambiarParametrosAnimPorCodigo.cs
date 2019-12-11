using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarParametrosAnimPorCodigo : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.Play("Escala");
    }
    void Update()
    {
        /*
        anim.SetFloat("FloatP", Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("TriggerP");
        }*/
    }

    public void SayHello()
    {
        
    }
}
