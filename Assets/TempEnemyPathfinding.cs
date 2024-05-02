using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class TempEnemyPathfinding : MonoBehaviour
{
    [SerializeField] GameObject ImpAttackScript;
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    private float distance;
    private float horizontalOne;
    private float horizontalTwo;
    private bool allowSecondRoutine = false;
    private bool allowSecondDirectionRoutine = false;
    private bool directionChanged = false;
    private bool preventMovement;
    private Animator anim;
    private bool currentDirectionisRight;
    private bool firstDirection;
    private bool secondDirection;
    private bool comparisonPossible = false;
    private bool InitialDirectionSet = false;

    public bool flipAttackArea;
    public bool attackDistance;
    public bool preventFlipBody = false;




    private void Start()
    {

    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 10)
        {
            if (distance < 1)
            {
                attackDistance = true;
                print("attackDistance enabled");
                StartCoroutine(PauseForAttack());

            }
            else
            {
                attackDistance = false;
                ImpAttackScript ImpAtt = ImpAttackScript.GetComponent<ImpAttackScript>();
                DisablePreventFlipBody();
                ImpAtt.DisablePreventFlipAttackArea();
                Vector2 direction = player.transform.position - transform.position;

                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);




            }


        }




        CheckDirection();
        if (preventFlipBody == false)
        {
            Flip();
        }
        if (InitialDirectionSet)
        {
            StartCoroutine(CompareNextDirectionOne());
            if (allowSecondDirectionRoutine)
            {
                StartCoroutine(CompareNextDirectionTwo());
            }
            if (comparisonPossible)
            {
                if (firstDirection == secondDirection)
                {
                    directionChanged = false;

                }
                if (firstDirection != secondDirection)
                {
                    directionChanged = true;
                    print("Direction Changed");
                }
            }



        }
    }
    private IEnumerator PauseForAttack()
    {
        preventMovement = true;

        yield return new WaitForSeconds(1); //adjust time here if it is too little/too less for animation. Animation code should go in BEFORE this statement
        preventMovement = false;
    }

    private void CheckDirection()
    {
        StartCoroutine(GetHorizontalOne());
        if (allowSecondRoutine)
        {
            StartCoroutine(GetHorizontalTwo());
        }
        //StartCoroutine(GetHorizontalTwo());
        if (horizontalOne != horizontalTwo)
        {
            
            if (horizontalOne < horizontalTwo)
            {
                //print("H1: " + horizontalOne + " H2: " + horizontalTwo + ". SHOULD be facing right");
                currentDirectionisRight = true;
                InitialDirectionSet = true;

            }
            if (horizontalOne > horizontalTwo)
            {
                //print("H1: " + horizontalOne + " H2: " + horizontalTwo + ". SHOULD be facing left");

                currentDirectionisRight = false;
                InitialDirectionSet = true;


            }

        }
        if (horizontalOne == horizontalTwo)
        {
            //print("Paused Movement");
            anim.SetBool("IsWalking", false);
        }
    }

    private IEnumerator GetHorizontalOne()
    {
        yield return new WaitForSeconds(0.2f);
        horizontalOne = transform.position.x;
        yield return new WaitForSeconds(0.2f);
        allowSecondRoutine = true;


    }

    private IEnumerator GetHorizontalTwo()
    {
        horizontalTwo = transform.position.x;
        allowSecondRoutine = false;
        yield return null;

    }

    private IEnumerator CompareNextDirectionOne()
    {
        yield return new WaitForSeconds(0.1f);
        firstDirection = currentDirectionisRight;
        yield return new WaitForSeconds(0.1f);
        allowSecondDirectionRoutine = true;
    }
    private IEnumerator CompareNextDirectionTwo()
    {
        secondDirection = currentDirectionisRight;
        comparisonPossible = true;
        yield return new WaitForSeconds(0.1f);
    }

    private void SetYValue(float n)
    {
        transform.position = new Vector3(transform.position.x, n, transform.position.z);
    }

    private void Flip()
    {


        {
            if (directionChanged)
            {
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
                flipAttackArea = true;
                directionChanged = false;
            }


        }



    }
    public void SwitchPreventFlipBody()
    {
        preventFlipBody = !preventFlipBody;
        Debug.Log("preventFlipB has been switched to: " + preventFlipBody);
    }

    public void EnablePreventFlipBody()
    {
        preventFlipBody = true;
    }

    public void DisablePreventFlipBody()
    {
        preventFlipBody = false;
    }
}

