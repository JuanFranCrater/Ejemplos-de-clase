using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GetComponentInParent<Animator>().SetBool("Fly", true);
            GetComponentInParent<DetectPlayer>().irAPorPlayer(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GetComponentInParent<Animator>().SetBool("Fly", false);
        }
    }

    private void irAPorPlayer(Collider other)
    {
        if (GetComponent<Transform>() != null && GetComponent<Rigidbody>() != null)
        {
            GetComponent<Transform>().LookAt(other.gameObject.transform);
        }
    }
}
