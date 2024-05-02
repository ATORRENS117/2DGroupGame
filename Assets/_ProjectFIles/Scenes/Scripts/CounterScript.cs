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

    [Range(1,10)]
    public float counterCooldown = 5.0f;
    private bool hitRegistered;
    private bool canCounter;
    private bool attackAttempted;
    private bool repeatButtonDown;
    [SerializeField] GameObject healthScriptRef;


    [Header("UI Components")] 
    public UI_SliderController counterSliderUI;

    private float counterMaxValue = 1f;
    private float counterCurrentValue = 0f;
    
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        
        canCounter = true;
        hitRegistered = false;
        counterOn = false;
        
        SetTempVisualButton(false);
        SetTempVisualCooldown(false);
        
        if (counterSliderUI != null)
        {
            //these can be dynamic values eventually - for now 0 and 1 are fine for the ui slider
            counterCurrentValue = counterMaxValue;
            counterSliderUI.SetMax(counterMaxValue);
            counterSliderUI.SetFill(counterCurrentValue);
        }
        else
        {
            Debug.Log("Counter Slider UI is not set in the inspector: This is a UI component to show the counter bar.");
        }
    }

    void Update()
    {
        attackAttempted = healthScriptRef.GetComponent<HealthManagement>().attackTriggered;
        hitRegistered = attackAttempted;

        if (canCounter)
        {
            if (Input.GetMouseButtonDown(1)) //only triggers on actual click not hold so need a continuous routine triggered but not included here
            {
                //TempButtonDownVisual.SetActive(true);
                SetTempVisualButton(true);
                counterOn = true;
                repeatButtonDown = true;
                StartCoroutine(ButtonHeldDown());
                playerAnimator.SetBool("Counter", true);
            }

            if (Input.GetMouseButtonUp(1))
            {
                counterOn = false;
                //TempButtonDownVisual.SetActive(false);
                SetTempVisualButton(false);
                repeatButtonDown = false;
            }
        }
        if (!counterOn)
        {
            playerAnimator.SetBool("Counter", false);
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
        //set the ui slider to 0
        counterSliderUI.SetFill(0f);
        
        canCounter = false;
        counterOn = false;
        hitRegistered = false;
        // TempCooldownVisual.SetActive(true);
        // TempButtonDownVisual.SetActive(false);
        yield return new WaitForSeconds(counterCooldown);
//        TempCooldownVisual.SetActive(false);
        canCounter = true;

        //set the ui slider to max
        counterSliderUI.SetFill(counterMaxValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            hitRegistered = true;
        }
    }
    
    #region Tempory Visual Debugs
    
    //-- TEMP Debugs -------------------------------------------------------------------------
    //function to set temp button down visuals
    public void SetTempVisualButton(bool state)
    {
        if(TempButtonDownVisual)
        {
            TempButtonDownVisual.SetActive(state);
        }
        
    }
    //function to set temp button down visual cooldown
    public void SetTempVisualCooldown(bool state)
    {
        if (TempCooldownVisual)
        {
            TempCooldownVisual.SetActive(state);
        }
    }
    #endregion
    
}