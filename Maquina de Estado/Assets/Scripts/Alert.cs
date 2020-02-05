using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alert : MonoBehaviour
{
    public AudioClip alertSound;

    private Quaternion targetRot;

    private Animator anim;
    private NavMeshAgent navmeshAgent;
    private AudioSource audioSource;

    private void Awake()
    {
        enabled = true;
        anim = GetComponent<Animator>();
        navmeshAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, navmeshAgent.angularSpeed * Time.deltaTime);        
    }

    public void StartState(Transform targeT)
    {
        UpdateTargeRot(targeT);
        enabled = true;
        anim.SetBool("IsWalking", false);
        navmeshAgent.enabled = false;
        audioSource.PlayOneShot(alertSound);
    }

   public void UpdateState(Transform targetT)
    {
        UpdateTargeRot(targetT);
    }


    public void StopState()
    {
        enabled = false;   
    }

    private void UpdateTargeRot(Transform targeT)
    {
        if (targeT)
        {
            targetRot = Quaternion.LookRotation(targeT.position - transform.position);
        }
        else
        {
            targetRot = transform.rotation;
        }
    }

 
}
