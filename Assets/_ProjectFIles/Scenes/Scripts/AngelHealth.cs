using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelHealth : MonoBehaviour
{
    
    private bool death;

    [SerializeField] private int health = 5;
    [SerializeField] GameObject hurtMask;

    private int MaxHealth = 5;

    [SerializeField] AngelHPManager healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<AngelHPManager>();
        hurtMask.SetActive(false);
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
        StartCoroutine(ShowHurt());

        if (health <= 0)
        {
            StartCoroutine(Die());

        }
        
    }

    private IEnumerator ShowHurt()
    {
        hurtMask.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hurtMask.SetActive(false);
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
