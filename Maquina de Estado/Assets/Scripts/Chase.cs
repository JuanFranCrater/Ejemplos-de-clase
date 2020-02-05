using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public AudioClip chaseSound;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            navmeshAgent.isStopped = true;
            anim.SetBool("IsWalking", false);
            GameManager.instance.GameOver();
        }
    }

    public void StartState(Transform targetT)
    {
        enabled = true;
        anim.SetBool("IsWalking", true);
        navmeshAgent.enabled = true;
        navmeshAgent.SetDestination(targetT.position);

        GameManager.instance.UpdateEnemiesChasing(+1);

        audioSource.PlayOneShot(chaseSound);
    }

    public void UpdateState(Transform targetT)
    {
        navmeshAgent.SetDestination(targetT.position);
    }

    public void StopState()
    {
        enabled = false;
        GameManager.instance.UpdateEnemiesChasing(-1);
    }
}
