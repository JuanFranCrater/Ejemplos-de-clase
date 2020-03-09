using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Async
{
    public class ParallelJobSystemDemo : MonoBehaviour
    {
        private float m_MyNumber = 10;
        private NativeArray<float> m_MyData;
        private JobHandle m_ParallelJobHandle;

        private void FreeMemoryData()
        {
            m_MyData.Dispose();
        }
        private void InitializeMemoryData()
        {
            m_MyData = new NativeArray<float>(100, Allocator.TempJob);
            //fill the data in the array
            for (int i = 0; i < m_MyData.Length; i++)
            {
                m_MyData[i] = i;
            }
        }

        private void RunDemo()
        {
            ParallelJob parallelJob = new ParallelJob
            {
                Number = m_MyNumber,
                Data = m_MyData
            };

            m_ParallelJobHandle = parallelJob.Schedule(m_MyData.Length, 32);

            JobHandle.ScheduleBatchedJobs();
            m_ParallelJobHandle.Complete();
            if (m_ParallelJobHandle.IsCompleted)
            {
                for (int i = 0; i < m_MyData.Length; i++)
                {
                    Debug.Log(parallelJob.Data[i]);                                                                                                                                                                                                                                                                                                                                                                                 
                }
                FreeMemoryData();
            }
        }
        public struct ParallelJob : IJobParallelFor
        {
            public float Number;
            public NativeArray<float> Data;

            //Operations done on large data
            public void Execute(int index)
            {
                Data[index] += Number;
            }
        }
    }
}