using System;
using System.Collections;
using UnityEngine;

public class Empty : IMagazineState
{
    public void Shoot(Magazine magazine)
    {
        Debug.Log("Click");
    }

    public IEnumerator Reload(Magazine magazine)
    {
        magazine.IsReloading = true;
        yield return new WaitForSeconds(magazine.ReloadDuration);
        magazine.CurrentBullets = magazine.Size;
        magazine.IsEmpty = false;
        magazine.CurrentState = new Full();
        magazine.IsReloading = false;
    }
}