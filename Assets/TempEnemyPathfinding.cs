using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class TempEnemyPathfinding : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float speed;
    private float distance;


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



    }


    private void SetYValue(float n)
    {
        transform.position = new Vector3(transform.position.x, n, transform.position.z);

    }


}

