using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Async
{
    public struct SimpleJob : IJob
    {
        public float Number;
        public NativeArray<float> Data;

        public void Execute()
        {
            Data[0] += Number;
        }
    }
}