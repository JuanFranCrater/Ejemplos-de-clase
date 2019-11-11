using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour 
{
    public float maxHealth;
    public float currentHealth;
    public Image healthBar;
    public UnityEvent onDie;
    public UnityEvent onHit;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUIBar();
    }

    public void UpdateHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        UpdateUIBar();
    }

    public void TakeDamage(float amount)
    {
        UpdateHealth(-amount);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int amount)
    {
        UpdateHealth(amount);
    }

    public void RecoverAllHealth()
    {
        UpdateHealth(maxHealth);
    }

    public float GetPercentageHealth()
    {
        return (float) currentHealth / maxHealth;
    }

    public void Die()
    {
        onDie.Invoke();
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }

    public void UpdateUIBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = GetPercentageHealth();
            onHit.Invoke(); 
        }
    }
}
