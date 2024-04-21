using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash_Icon : MonoBehaviour
{
    private WaitForSeconds regenDash = new WaitForSeconds(0.1f);
    private Coroutine regen;
    public Slider slider;
    // Start is called before the first frame update
    
    public void SetMaxDash(int dash)
    { 
        slider.maxValue = dash;
        slider.value = dash;
        if (regen != null)
            StopCoroutine(regen);
        regen = StartCoroutine(RegenDash());
        
    }

    public void SetDash(int dash)
    { 
    slider.value = (dash);
        
    }
    private IEnumerator RegenDash()
    {
        yield return new WaitForSeconds(2);

        while (slider != null)
        {
            slider.maxValue += slider.value / 100;
            slider.value = slider.maxValue;
            yield return regenDash;

        }
        regen = null;
    }
}
//You know this would be a lot less stressful if I wasn't under a time limit...or inexperienced.