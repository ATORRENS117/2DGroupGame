using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dash_Icon : MonoBehaviour
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
    slider.value = (dash);
    }
}
//You know this would be a lot less stressful if I wasn't under a time limit...or inexperienced.