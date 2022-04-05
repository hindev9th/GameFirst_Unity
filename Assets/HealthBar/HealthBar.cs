using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int heath)
    {
        slider.maxValue = heath;
        slider.value = heath;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int heath)
    {
        slider.value = heath;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxXP(int XP,int XPDefault)
    {
        slider.maxValue = XPDefault;
        slider.value = XP;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetXP(int XP){
        slider.value = XP;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}