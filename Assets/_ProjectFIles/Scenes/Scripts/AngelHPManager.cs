using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngelHPManager : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        slider.value = 5;
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
