using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CounterScript : MonoBehaviour
{


    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private Animator animator;
    [SerializeField] private GameObject player;
    //[SerializeField] private GameObject enemy;
    [SerializeField] private GameObject TempButtonDownVisual;
    [SerializeField] private GameObject TempCooldownVisual;

    public bool counterOn;

    private float counterCooldown = 6.0f;
    private bool hitRegistered;
    private bool canCounter;
    private bool attackAttempted;
    private bool repeatButtonDown;
    [SerializeField] GameObject healthScriptRef;


    private void Start()
    {
        canCounter = true;
        hitRegistered = false;
        counterOn = false;
        TempButtonDownVisual.SetActive(false);
        TempCooldownVisual.SetActive(false);
    }

    void Update()
    {
        attackAttempted = healthScriptRef.GetComponent<HealthManagement>().attackTriggered;
        hitRegistered = attackAttempted;

        if (canCounter)
        {
            if (Input.GetMouseButtonDown(1)) //only triggers on actual click not hold so need a continuous routine triggered but not included here
            {
                TempButtonDownVisual.SetActive(true);
                counterOn = true;
                repeatButtonDown = true;
                StartCoroutine(ButtonHeldDown());

            }

            if (Input.GetMouseButtonUp(1))
            {
                counterOn = false;
                TempButtonDownVisual.SetActive(false);
                repeatButtonDown = false;
            }



        }


    }



    private IEnumerator ButtonHeldDown()
    {
        if (hitRegistered == true)
        {

            StartCoroutine(TriggerCounter());
            counterOn = false;
            yield return null;
        }


        if (counterOn)
        {
            yield return null;
            StartCoroutine(ButtonHeldDown());
        }


    }


    private IEnumerator TriggerCounter()
    {
        canCounter = false;
        counterOn = false;
        hitRegistered = false;
        TempCooldownVisual.SetActive(true);
        TempButtonDownVisual.SetActive(false);
        yield return new WaitForSeconds(counterCooldown);
        TempCooldownVisual.SetActive(false);
        canCounter = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            hitRegistered = true;

        }
    }
}
