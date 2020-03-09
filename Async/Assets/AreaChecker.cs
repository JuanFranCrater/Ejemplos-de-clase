using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Async
{
    public class AreaChecker : MonoBehaviour
    {
        public float CheckRadius = 5f;
        public LayerMask TargetLayer;
        private AI m_Ai;

        private int m_PatrolCounter = 0;

        private void Awake()
        {
            m_Ai = GetComponent<AI>();
        }

        private void Update()
        {
          //  Patrols();
        }

        private void Start()
        {
            StartCoroutine(PatrolCoroutine());
        }
        IEnumerator PatrolCoroutine()
        {
            while (true)
            {
                Patrols();
                yield return new WaitForSeconds(0.25f);
            }
        }

        private void Patrols()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, CheckRadius, TargetLayer);

            Collider targeCollider = FindClosest(hitColliders);
            if (targeCollider != null)
            {
                m_Ai.Track(targeCollider.transform.position);
            }
            else
            {
                m_Ai.StopTracking();
            }
        }

        private Collider FindClosest(Collider[] hitColliders)
        {
            float closestDistance = int.MaxValue;
            Collider closestCollider = null;

            for (int i = 0; i < hitColliders.Length; i++)
            {
                float distance = GetCurrentDistance(hitColliders[i].transform.position);

                if (distance < closestDistance)
                {
                    closestCollider = hitColliders[i];
                    closestDistance = distance;
                }
            }
            return closestCollider;
        }

        private float GetCurrentDistance(Vector3 position)
        {
            return Vector3.Distance(position, transform.position);
        }

        private void PatrolCounter()
        {
            Debug.Log(m_PatrolCounter);
            m_PatrolCounter++;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, CheckRadius);
        }
    }
}