using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pratol : MonoBehaviour
{
    public List<Transform> patrolPointList;
    private int currentPatrolIndex;
    private Vector3 targetPos;
    private Quaternion targetRot;

    private NavMeshAgent navMeshAgent;
    private Animator anim;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        if (patrolPointList != null && HasPatrol())
        {
            for (int i = 0; i < patrolPointList.Count; i++)
            {
                if (i == patrolPointList.Count - 1)
                {
                    Gizmos.DrawLine(GetPatrolPos(i)+Vector3.up*0.5f,GetPatrolPos(0) + Vector3.up * 0.5f);
                }
                else 
                {
                    Gizmos.DrawLine(GetPatrolPos(i) + Vector3.up * 0.5f, GetPatrolPos(i+1) + Vector3.up * 0.5f);
                }
            }
        }
    }

    private Vector3 GetPatrolPos(int patrolIndex)
    {
        return patrolPointList[patrolIndex].position;
    }

    private void Awake()
    {
        enabled = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (HasPatrol())
        {
            targetPos = patrolPointList[0].position;
        }
        else
        {
            targetPos = transform.position;
            targetRot = transform.rotation;
        }
    }
    [ContextMenu("Test State")]
   public void StartState()
    {
        enabled = true;
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(targetPos);
    }

    public void StopState()
    {
        enabled = false;
    }

    private void CheckPatrol()
    {
        if (Vector3.Distance(targetPos, transform.position) < navMeshAgent.stoppingDistance)
        {
            if (HasPatrol())
            {
                UpdatePatrolIndex();
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, Time.deltaTime * navMeshAgent.angularSpeed);
                anim.SetBool("IsWalking", false);
            }
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    private void UpdatePatrolIndex()
    {
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPointList.Count;
        targetPos = GetPatrolPos(currentPatrolIndex);
        navMeshAgent.SetDestination(targetPos);
    }

    void Update()
    {
        CheckPatrol();
    }

    private bool HasPatrol()
    {
        return patrolPointList.Count > 0;
    }
}
