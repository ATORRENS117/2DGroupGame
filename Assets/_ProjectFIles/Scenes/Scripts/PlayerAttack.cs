using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackArea;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
            
        }

        if (attacking)
        {
            timer += Time.deltaTime;
            
            playerAnimator.SetBool("Attacking", true);

            if (timer > timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                playerAnimator.SetBool("Attacking", false);
                
                
                
                //TODO Set the Counter UI here to on or 1 if its a slider
                
                
            }
        }
    }

    private void Attack()
    {
        //TODO Set the Counter UI here to off or zero if its a slider

        attacking = true;
        attackArea.SetActive(attacking);
        
        
    }
}
