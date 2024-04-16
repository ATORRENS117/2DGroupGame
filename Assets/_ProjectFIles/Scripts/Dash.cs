using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dash : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    
    public void SetMaxDash(int dash)
    { 
        slider.maxValue = dash;
        slider.value = dash; 
    }
    public void SetDash(int dash)
    { 
    slider.value = dash;
    }
}
//You know, this would be less stressful if I wasn't under a time limit...and inexperienced