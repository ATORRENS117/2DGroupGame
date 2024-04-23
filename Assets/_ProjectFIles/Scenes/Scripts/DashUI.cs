using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{

    public Slider slider;
    public float maxDash;
    public float dash;
    [Range(1,10)]
    public float lerpSpeed = 5f;
    
    
    public void SetMaxDash(float value)
    { 
        maxDash = value;
        slider.maxValue = maxDash;
        slider.value = dash;
        
    }

    public void SetDash(float value)
    { 
        dash = value;
        //slider.value = (dash);
    }
    
    //update function to update the dash value using lerping
    private void Update()
    {
        //lerp the slider value to the dash value
        slider.value = Mathf.Lerp(slider.value, dash, Time.deltaTime * 5f);
    }
}