using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReloadBar : MonoBehaviour
{
    public Slider Slider;
    public Magazine Magazine;
    public bool ReloadShouldStart => Magazine.IsReloading && Slider.value == Slider.maxValue;
    void Start()
    {
        Slider.minValue = 0;
        Slider.maxValue = Magazine.ReloadDuration;
    }
    void Update()
    {
        if (ReloadShouldStart)
        {
            StartCoroutine(UpdateSlider());
        }
    }
    IEnumerator UpdateSlider()
    {
        Slider.value = Slider.value - Time.deltaTime;
        yield return null;
    }
}
