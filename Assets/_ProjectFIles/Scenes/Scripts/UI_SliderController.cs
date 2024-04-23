using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
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
    public float maxDash; //set from external script
    public float dash; //set from external script
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
        maxDash = value;
        slider.maxValue = maxDash;
        slider.value = dash;
        
    }

    public void SetFill(float value)
    { 
        dash = value;
        //slider.value = (dash);
    }
    public void SetFill(float value, float speed)
    { 
        dash = value;
        lerpSpeed = speed;
        //slider.value = (dash);
    }
    
    //update function to update the dash value using lerping
    private void Update()
    {
        //lerp the slider value to the dash value
        slider.value = Mathf.Lerp(slider.value, dash, Time.deltaTime * 5f);
        
        //change the colour of the fill based on the value of the dash
        slider.fillRect.GetComponent<Image>().color = Color.Lerp(emptyColour, fillColour, dash / maxDash);
    }
}