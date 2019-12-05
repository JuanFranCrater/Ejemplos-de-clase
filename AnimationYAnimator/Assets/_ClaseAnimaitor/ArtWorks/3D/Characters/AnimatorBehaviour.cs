using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBehaviour : MonoBehaviour
{
    Animator anim;
    float speedMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        speedMultiplier = Input.GetAxis("Vertical");
        anim.SetFloat("speedMultiplier", anim.GetFloat("speedMultiplier") + speedMultiplier);
        */
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetFloat("speedMultiplier", anim.GetFloat("speedMultiplier") + Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetFloat("speedMultiplier", anim.GetFloat("speedMultiplier") - Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }

    }
}
