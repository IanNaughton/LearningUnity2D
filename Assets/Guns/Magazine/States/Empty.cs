using System;
using System.Collections;
using UnityEngine;

public class Empty : IMagazineState
{
  public void Init(Magazine magazine)
  {
    magazine.IsEmpty = false;
    magazine.IsReloading = false;
    magazine.CurrentState = new Full();
  }
  public void Shoot(Magazine magazine)
  {
    Debug.Log("Click");
  }

  public IEnumerator Reload(Magazine magazine)
  {
    
    if (!magazine.IsReloading)
    {
      magazine.IsReloading = true;
      var currentValue = 0f;
      while (currentValue < magazine.ReloadBar.Slider.maxValue)
      {
        magazine.ReloadBar.Slider.value = currentValue;
        currentValue += Time.deltaTime;
        yield return null;
      }
      magazine.ReloadBar.Slider.value = magazine.ReloadBar.minValue;
      magazine.CurrentBullets = magazine.Size;
      magazine.IsEmpty = false;
      magazine.CurrentState = new Full();
      magazine.IsReloading = false;
    }
  }
}