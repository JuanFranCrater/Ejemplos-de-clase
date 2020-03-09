using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Async
{
    public class AI : MonoBehaviour
    {
        public float MaxMoveDistance = 5;

        private NavMeshAgent m_Agent;

        private bool m_Tracking = false;
        private Vector3 m_MovePosition;

        private void Awake()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            
        }
        private void Update()
        {
            Think();
        }

        public void Think()
        {
            float distance = m_Agent.remainingDistance;
            if(!m_Tracking && (distance<2||distance>20))
            {
                RandomMove();
            }
        }

        public void Track(Vector3 position)
        {
            m_Tracking = true;
            m_MovePosition = position;
            m_Agent.SetDestination(m_MovePosition);
        }

        public void StopTracking()
        {
            m_Tracking = false;
        }
        private void RandomMove()
        {
            NavMeshHit hit;
            NavMesh.SamplePosition(Random.insideUnitSphere * MaxMoveDistance, out hit, MaxMoveDistance, NavMesh.AllAreas);
            m_MovePosition = hit.position;
            m_Agent.SetDestination(m_MovePosition);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(m_MovePosition, 1f);
        }
    }
}