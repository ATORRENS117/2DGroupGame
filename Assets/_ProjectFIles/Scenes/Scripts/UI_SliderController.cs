using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_SliderController : MonoBehaviour
{
    [Header("Slider Settings")] 
    public bool lerpColour = true;
    public bool setColours = true;
    
    [Space(10)]
    [Header("Slider Colours")]
    public Color fillColour;
    public Color emptyColour = Color.yellow;
    
    [Space(10)]
    [Header("Slider Reference and Values")]
    public Slider slider;
    public float maxValue; //set from external script
    public float currentValue; //set from external script
    public float lerpSpeed = 5f; //set from external script
    


    private void Start()
    {
        if (setColours)
        {
            //set the slider colour to the fill colour
            slider.fillRect.GetComponent<Image>().color = fillColour;
        }
        else
        {
            //get the fillcolour from the slider
            fillColour = slider.fillRect.GetComponent<Image>().color;
        }
        
    }

    public void SetMax(float value)
    { 
        maxValue = value;
        slider.maxValue = maxValue;
        slider.value = currentValue;
        
    }

    public void SetFill(float value)
    { 
        currentValue = value;
        //slider.value = (dash);
    }
    public void SetFill(float value, float speed)
    { 
        currentValue = value;
        lerpSpeed = speed;
        //slider.value = (dash);
    }
    
    //update function to update the dash value using lerping
    private void Update()
    {
        //lerp the slider value to the dash value
        slider.value = Mathf.Lerp(slider.value, currentValue, Time.deltaTime * lerpSpeed);
        
        //change the colour of the fill based on the value of the dash
        if(lerpColour)
        {
            slider.fillRect.GetComponent<Image>().color = Color.Lerp(emptyColour, fillColour, currentValue / maxValue);
        }
        
    }
}