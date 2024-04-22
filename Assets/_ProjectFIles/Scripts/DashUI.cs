using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{

    public Slider slider;
    
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