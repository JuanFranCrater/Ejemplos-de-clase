using Async;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text UIValue;

    private void Awake()
    {
        PlayerManager.Instance.UpdateHealth += UpdateHealth;
    }

    private void OnDestroy()
    {
        PlayerManager.Instance.UpdateHealth -= UpdateHealth;
    }

    public void UpdateHealth(int health)
    {
        UIValue.text = PlayerManager.Instance.Health.ToString();
    }
}
