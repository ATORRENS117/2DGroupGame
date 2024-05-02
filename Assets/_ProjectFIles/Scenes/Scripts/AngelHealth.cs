using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelHealth : MonoBehaviour
{
    
    private bool death;

    [SerializeField] public int Angelhealth = 15;
    [SerializeField] GameObject hurtMask;

    public bool respawnPossible = true;

    private int MaxHealth = 15;

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

        this.Angelhealth -= amount;
        healthBar.UpdateHealthBar(Angelhealth, MaxHealth);
        print("SHould be damaging angel");
        StartCoroutine(ShowHurt());

        if (Angelhealth <= 0)
        {
            StartCoroutine(Die());

        }
        
    }

    private IEnumerator ShowHurt()
    {
        print("Inside SHOWHURT");
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

        bool wouldBeOverMaxHealth = Angelhealth + amount > MaxHealth;

        if (wouldBeOverMaxHealth)
        {
            this.Angelhealth = MaxHealth;
            healthBar.UpdateHealthBar(Angelhealth, MaxHealth);
        }
        else
        {
            this.Angelhealth += amount;
            healthBar.UpdateHealthBar(Angelhealth, MaxHealth);
        }
    }

    private IEnumerator Die()
    {
        respawnPossible = false;
        Debug.Log("Angel Dead");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
