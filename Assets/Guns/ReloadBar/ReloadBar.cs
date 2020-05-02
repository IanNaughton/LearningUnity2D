using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReloadBar : MonoBehaviour
{
    public Slider Slider;

    public void Start()
    {
        gameObject.SetActive(false);
    }
    public IEnumerator Reload()
    {
        Debug.Log("Starting to reload");
        gameObject.SetActive(true);
        var currentValue = 0f;
        while (currentValue < Slider.maxValue)
        {
            Debug.Log($"Current reload bar progress: {currentValue}");
            Slider.value = currentValue;
            currentValue += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Resetting log to zero");
        gameObject.SetActive(false);
        Slider.value = Slider.minValue;
    }
}
