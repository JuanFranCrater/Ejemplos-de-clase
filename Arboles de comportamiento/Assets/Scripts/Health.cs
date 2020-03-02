using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Image healthBar;

    void Start()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth <= 0)
        {
            Die();
        }

        if(healthBar != null)
        {
            healthBar.fillAmount = (float) currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        if(gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
