using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HellEnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;

    private int MaxHealth = 3;

    [SerializeField] EnemyHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Damage(1);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Heal(1);
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Error: Can't have negative Damage");
        }

        this.health -= amount;
        healthBar.UpdateHealthBar(health, MaxHealth);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("ERROR: Can't have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MaxHealth;

        if (wouldBeOverMaxHealth)
        {
            this.health = MaxHealth;
            healthBar.UpdateHealthBar(health, MaxHealth);
        }
        else
        {
            this.health += amount;
            healthBar.UpdateHealthBar(health, MaxHealth);
        }
    }

    private void Die()
    {
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }
}