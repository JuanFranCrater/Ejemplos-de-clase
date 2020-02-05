using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum State
    {
        Patrol, Alert, Chasing
    }

    [Header("States")]
    public State state;
    public Pratol patrol;
    public Alert alert;
    public Chase chase;

    [Header("Senses")]
    public float hearingDistance;
    public float viewDistance;
    public float angleView;
    public float heightView;
    public LayerMask playerLayer;
    public LayerMask obstacleLayer;

    [Header("Times")]
    public float alertTime;
    private float alertTimer;
    public float chaseTime;
    private float chaseTimer;

    [Header("Lights")]
    public Light stateLight;
    public List<Color> colorStateList;

    private Collider[] collidersDetected;
    private Transform playerDetected;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, hearingDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
        Vector3 dir = Quaternion.Euler(0, angleView / 2, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, dir * viewDistance);
        dir = Quaternion.Euler(0, -angleView / 2, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, dir * viewDistance);
    }

    private void Start()
    {
        SetState(State.Patrol);
        patrol.StartState();
    }

    private void Update()
    {
        CheckStates();
    }

    private void CheckStates()
    {
        switch (state)
        {
            case State.Patrol:
                playerDetected = CheckSight();
                if (playerDetected)
                {
                    patrol.StopState();
                    chase.StartState(playerDetected);
                    SetState(State.Chasing);
                    chaseTimer = chaseTime;
                }
                playerDetected = checkHear();
                if (playerDetected)
                { 
                    patrol.StopState();
                    alert.StartState(playerDetected);
                    SetState(State.Alert);
                    alertTimer = alertTime;
                }

                break;

            case State.Alert:
                playerDetected = CheckSight();
                if (playerDetected)
                {
                    alert.StopState();
                    chase.StartState(playerDetected);
                    SetState(State.Chasing);
                    chaseTimer = chaseTime;
                }

                playerDetected = checkHear();
                if (playerDetected)
                {
                    alert.UpdateState(playerDetected);
                    alertTimer = alertTime;
                }
                else 
                {
                    alertTimer -= Time.deltaTime;
                    if (alertTimer < 0)
                    {
                        alert.StopState();
                        patrol.StartState();
                        SetState(State.Patrol);
                    }
                }

                break;
            case State.Chasing:
                playerDetected = CheckSight();
                if (playerDetected)
                {
                    chaseTimer = chaseTime;
                    chase.UpdateState(playerDetected);
                }
                else
                {
                    playerDetected = checkHear();
                    if (playerDetected)
                    {
                        chaseTimer = chaseTime;
                        chase.UpdateState(playerDetected);
                    }
                    else {

                        chaseTimer -= Time.deltaTime;
                        if (chaseTimer < 0)
                        {
                            chase.StopState();
                            alert.StartState(null);
                            SetState(State.Alert);
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    private Transform checkHear()
    {
        collidersDetected = Physics.OverlapSphere(transform.position, hearingDistance, playerLayer);
        if (collidersDetected.Length > 0 && collidersDetected[0].GetComponent<PlayerController>().IsWalking())
        {
            return collidersDetected[0].transform;
        }
        else
        {
            return null;
        }
    }

    private Transform CheckSight()
    {
        collidersDetected = Physics.OverlapSphere(transform.position, viewDistance, playerLayer);

        if (collidersDetected.Length > 0)
        {
            Vector3 playerDir = collidersDetected[0].transform.position - transform.position;
            if (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(playerDir)) < angleView)
            {
                if (Physics.Raycast(transform.position + Vector3.up * heightView, playerDir, viewDistance, obstacleLayer))
                {
                    return collidersDetected[0].transform;
                }
            }
        }
            return null;
    }
    private void SetState(State newState)
    {
        state = newState;
        stateLight.color = colorStateList[(int)state];
    }

}