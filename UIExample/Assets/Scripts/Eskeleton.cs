using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Eskeleton : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent _navMeshAgent;
    private Animator _anim;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update ()
    {
        _navMeshAgent.SetDestination(goal.position);
        _anim.SetFloat("Speed", _navMeshAgent.velocity.magnitude);
    }
}
