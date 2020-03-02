using Avendevs.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editores
{
    public class SpawnManager : Singleton<SpawnManager>
    {
        public List<Transform> SpawnPoints;

        [Header("Used for debug")]
        public List<Color> SpawnColors;

        public void MoveYSpawnPoints(float yAmount)
        {
            foreach (Transform transform in SpawnPoints)
            {
                transform.position += new Vector3(0, yAmount, 0);
            }
        }

        //Cuidado: solo se ejecuta en el editor y es para hacer Debug
        private void OnDrawGizmos()
        {
            DrawSpawnPoints();
        }

        private void DrawSpawnPoints()
        {
            if (SpawnPoints != null && SpawnColors != null)
            {
                for (int i = 0; i < SpawnPoints.Count; i++)
                {
                    Color color = (i < SpawnColors.Count ? SpawnColors[i] : SpawnColors[0]);
                    Gizmos.color = color;
                    Gizmos.DrawSphere(SpawnPoints[i].position, 1f);
                }
            }
        }
    }
}