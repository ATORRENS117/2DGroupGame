using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpAttackTrigger : MonoBehaviour
{
    [SerializeField] private GameObject attackArea;

    public bool attacking = false;

    private float timeToAttack = 0.3f;
    private float timer = 0f;
    private float animationLength = 1; //Set this to whatever time you need for wind up animation
    private bool windUpAnimationComplete = false;
    private bool closeEnoughToAttack = false;
    private Animator anim; 

    [SerializeField] GameObject enemyPathFinding;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        closeEnoughToAttack = enemyPathFinding.GetComponent<EnemyPathfinding>().attackDistance;
        if (closeEnoughToAttack)
        {
            attacking = true;
            
        }
        else
        {
            attacking = false;  
        }
        if (attacking)
        {
            anim.SetBool("Attacking", true); 
            attackArea.SetActive(true);
        }
        else
        {
            attackArea.SetActive(false);
            anim.SetBool("Attacking", false);
        }
    }


}