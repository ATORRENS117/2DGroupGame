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
    private Animator animator;
    [SerializeField] GameObject EnemyMovementScriptRef;
    [SerializeField] GameObject HealthScriptRef;
    [SerializeField] GameObject ImpAttackTriggerRef;


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
            
        }
        
    }
    private void Attack()
    {
        HealthManagement healthMan = HealthScriptRef.GetComponent<HealthManagement>();
        playerHealth = HealthScriptRef.GetComponent<HealthManagement>().health;
        if (playerHealth != 0)
        {
            print("Hit here!"); 
        }
        else
        {
            print("for some reason not hit?");
        }

    }

    private void FixedUpdate()
    {
        if (flipAttackAreaTrigger)
        {
            flipAttackAreaTrigger = EnemyMovementScriptRef.GetComponent<TempEnemyPathfinding>().flipAttackArea;
            Flip();
            flipAttackAreaTrigger = false;
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
}

