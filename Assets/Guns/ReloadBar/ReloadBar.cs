using System.Collections;
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
        gameObject.SetActive(true);
        var currentValue = 0f;
        while (currentValue < Slider.maxValue)
        {
            Slider.value = currentValue;
            currentValue += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
        Slider.value = Slider.minValue;
    }
}