using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Async
{
    public class HealthBarUi : MonoBehaviour
    {
        public Slider HealthSlider;

        private int MaxHealthValue = 1000;

        public void UpdateHealth(int health)
        {
            float normalizedHealth = health / (float)MaxHealthValue;
            HealthSlider.normalizedValue = normalizedHealth;
        }

        private void Awake()
        {
            PlayerManager.Instance.UpdateHealth += UpdateHealth;
        }

        private void OnDestroy()
        {
            PlayerManager.Instance.UpdateHealth -= UpdateHealth;
        }

    }
}