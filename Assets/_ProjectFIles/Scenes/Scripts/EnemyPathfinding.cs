using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class EnemyPathfinding : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float speed;
    private float distance;
    private float horizontalOne;
    private float horizontalTwo;
    private bool isFacingRight = true;
    private bool allowSecondRoutine = false;
    private bool previousIsFacingRightValue;
    private bool directionChanged;



    private void Start()
    {

    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 10)
        {

            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);


        }




        CheckDirection();
        Flip();



    }

    private void CheckDirection()
    {
        StartCoroutine(GetHorizontalOne());
        if (allowSecondRoutine)
        {
            StartCoroutine(GetHorizontalTwo());
        }
        StartCoroutine(GetHorizontalTwo());
        if (horizontalOne != horizontalTwo)
        {
            previousIsFacingRightValue = isFacingRight;
            if (horizontalOne < horizontalTwo)
            {
                isFacingRight = true;

            }
            if (horizontalOne > horizontalTwo)
            {
                isFacingRight = false;


            }

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

    private void SetYValue(float n)
    {
        transform.position = new Vector3(transform.position.x, n, transform.position.z);
    }

    private void Flip()
    {

        if (isFacingRight != previousIsFacingRightValue)
        {
            directionChanged = true;
        }
        if (isFacingRight == previousIsFacingRightValue)
        {
            directionChanged = false;
        }
        if (directionChanged)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }


    }


}

