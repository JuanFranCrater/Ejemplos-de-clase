using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Async
{
    public class ThreadExample : MonoBehaviour
    {
        public int loops = 100000;


        private void Start()
        {
            LaunchThread();
            StartCoroutine(CoroutineTest());
        }
        public void ThreadTest()
        {
            for (int i = 0; i < loops; i++)
            {
                Debug.Log(i);
                Thread.Sleep(1);
            }

            Debug.Log("Thread fin!");
        }

        public void LaunchThread()
        {
            Thread t = new Thread(new ThreadStart(ThreadTest));
            t.Start();
        }

        public IEnumerator CoroutineTest()
        {
            for (int i = 0; i < loops; i++)
            {
                Debug.LogError(i);
                yield return null;
            }
            Debug.Log("Coroutine fin!");
        }
    }
}