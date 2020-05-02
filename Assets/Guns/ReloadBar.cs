using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReloadBar : MonoBehaviour
{
    public Slider Slider;
    public IEnumerator Reload()
    {
        var currentValue = 0f;
        while (currentValue < Slider.maxValue)
        {
            Slider.value = currentValue;
            currentValue += Time.deltaTime;
            yield return null;
        }
        Slider.value = Slider.minValue;
    }
}
