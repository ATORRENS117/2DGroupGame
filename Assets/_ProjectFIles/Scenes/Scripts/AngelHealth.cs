using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelHealth : MonoBehaviour
{
    
    private bool death;

    [SerializeField] private int health = 5;

    private int MaxHealth = 5;

    [SerializeField] EnemyHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar>();
    }

    private void Update()
    {
       
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
            StartCoroutine(Die());

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

    private IEnumerator Die()
    {

        Debug.Log("Angel Dead");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
