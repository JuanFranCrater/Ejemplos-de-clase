using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
namespace Async
{
    public class SimpleJobSystemDemo : MonoBehaviour
    {
        //float to adds in the myData
        private float m_MyNumber = 5;
        //Simple native container of type float
        private NativeArray<float> m_MyData;
        //Handle use to operate job in main thread
        private JobHandle SimpleJobHandle;

        private void OnEnable()
        {
            InitializeMemoryData();
        }
        private void Start()
        {
            RunDemo();
        }

        private void RunDemo()
        {
            //Simple job declaration with the data
            SimpleJob simpleJob = new SimpleJob
            {
                Number = m_MyNumber,
                Data = m_MyData

            };

            SimpleJobHandle = simpleJob.Schedule();
        }

        private void FreeMemoryData()
        {
            m_MyData.Dispose();
        }

        private void InitializeMemoryData()
        {
            m_MyData = new NativeArray<float>(1, Allocator.Persistent);
            m_MyData[0] = 2;
        }
    }
}
