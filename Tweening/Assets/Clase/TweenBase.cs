using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTweens
{
    public abstract class TweenBase : MonoBehaviour
    {
        public float Duration;
        public float StartValue;
        public float EndValue;
        public Ease EaseCurve;
        public float Delay;
        public bool PlayOnStart = false;

        private float m_TimePlayed = 0;


        private void Start()
        {
            if (PlayOnStart)
            {
                Play();
               
            }
        }

        private void Play()
        {
            StartCoroutine(PlayTween());
        }

        public IEnumerator PlayTween()
        {
            yield return new WaitForSeconds(Delay);
            float timeValue = 0;
            float changeValue = EndValue - StartValue;

            while(!HasEnded())
            {
                timeValue = EaseCurve.Interpolate(m_TimePlayed, StartValue, changeValue, Duration);
                ApplyTween(timeValue);
                m_TimePlayed += Time.deltaTime;
                yield return 1;
            }
        }

        protected abstract void ApplyTween(float timeValue);
        protected abstract void Init();

        private bool HasEnded()
        {
            return (m_TimePlayed >= Duration);
        }
    }
}
