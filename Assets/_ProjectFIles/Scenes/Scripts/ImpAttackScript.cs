using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpAttackScript : MonoBehaviour
{
    private int damage = 1;
    private bool isFacingRight;
    public bool flipAttackAreaTrigger;
    private bool isAttacking;
    private int playerHealth;
    private bool attackRegistered;
    private bool finishedDelay = false;
    public bool preventFlipAttackA = false;
    private bool readPreventFlip;
    private Animator animator;
    [SerializeField] GameObject EnemyMovementScriptRef;
    [SerializeField] GameObject HealthScriptRef;
    [SerializeField] GameObject ImpAttackTriggerRef;

    private bool canDamage = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        isAttacking = ImpAttackTriggerRef.GetComponent<ImpAttackTrigger>().attacking;
        if (isAttacking)
        {
            Attack();
            EnemyPathfinding EnemyMovement = EnemyMovementScriptRef.GetComponent<EnemyPathfinding>();
            EnemyMovement.EnablePreventFlipBody();
            EnablePreventFlipAttackArea();
        }
        
    }
    private void Attack()
    {
        HealthManagement healthMan = HealthScriptRef.GetComponent<HealthManagement>();
        playerHealth = healthMan.health;
        if (playerHealth != 0)
        {
            print("Hit here!");
            attackRegistered = true;
        }
        else
        {
            print("for some reason not hit?");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            canDamage = true;
            StartCoroutine(DelayDmgInflict());
            
            // HealthManagement healthMan = HealthScriptRef.GetComponent<HealthManagement>();
            // healthMan.DamagePlayer(damage);
            // print("Damege inflicted!");
            // finishedDelay = false;
            // EnemyPathfinding EnemyMovement = EnemyMovementScriptRef.GetComponent<EnemyPathfinding>();
            // EnemyMovement.DisablePreventFlipBody();
            // DisablePreventFlipAttackArea();
            
            //this will never execute!
            if (finishedDelay)
            {
                HealthManagement healthMan = HealthScriptRef.GetComponent<HealthManagement>();
                healthMan.DamagePlayer(damage);
                print("Damege inflicted!");
                finishedDelay = false;
                EnemyPathfinding EnemyMovement = EnemyMovementScriptRef.GetComponent<EnemyPathfinding>();
                EnemyMovement.DisablePreventFlipBody();
                DisablePreventFlipAttackArea();
            }


        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            canDamage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            canDamage = false;
        }
    }


    private IEnumerator DelayDmgInflict()
    {

        finishedDelay = true;
        yield return new WaitForSeconds(0.3f);
        
        if (finishedDelay && canDamage)
        {
            HealthManagement healthMan = HealthScriptRef.GetComponent<HealthManagement>();
            healthMan.DamagePlayer(damage);
            print("Damege inflicted!");
            finishedDelay = false;
            EnemyPathfinding EnemyMovement = EnemyMovementScriptRef.GetComponent<EnemyPathfinding>();
            EnemyMovement.DisablePreventFlipBody();
            DisablePreventFlipAttackArea();
        }

    }
    private void FixedUpdate()
    {
        if (preventFlipAttackA == false)
        {
            if (flipAttackAreaTrigger)
            {
                flipAttackAreaTrigger = EnemyMovementScriptRef.GetComponent<TempEnemyPathfinding>().flipAttackArea;
                Flip();
                flipAttackAreaTrigger = false;
            }
        }
    }
    private void Flip()
    {
        if (isFacingRight || !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
  public void SwitchPreventFlipAttackArea()
    {
        preventFlipAttackA = !preventFlipAttackA;
        Debug.Log("preventFlipA has been switched to: " + preventFlipAttackA);
    }

    public void EnablePreventFlipAttackArea()
    {
        preventFlipAttackA = true;
    }

    public void DisablePreventFlipAttackArea()
    {
        preventFlipAttackA = false;
    }
}

