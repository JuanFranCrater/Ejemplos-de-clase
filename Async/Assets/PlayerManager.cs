using Avendevs.Utils;
using System;
using System.Collections;
using UnityEngine;

namespace Async
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        public int Health = 1000;

        //Forma A
        /*
        public delegate void HealthDelegate(int value);
        public HealthDelegate UpdateHealthDelegate;
        */
        //Forma B
        public Action<int> UpdateHealth;



        private void Start()
        {
            Play();
        }

        private void Play()
        {
            StartCoroutine(Simulate());  
        }
        IEnumerator Simulate()
        {
            while (true)
            {
               
                setPlayerHealth(UnityEngine.Random.Range(0, 1000));
                yield return new WaitForSeconds(UnityEngine.Random.Range(0, 5));
            }
        }

        private void setPlayerHealth(int amount)
        {
            this.Health = amount;
            if(UpdateHealth!=null)
            UpdateHealth(this.Health);
        }
    }
}