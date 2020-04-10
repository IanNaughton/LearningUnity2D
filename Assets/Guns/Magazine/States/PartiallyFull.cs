using System;
using System.Collections;
using UnityEngine;

public class PartiallyFull : IMagazineState
{
    public void Shoot(Magazine magazine)
    {
        if (magazine.CurrentBullets >= 1)
        {
            magazine.CurrentBullets -= 1;
        }
        else
        {
            Debug.Log("*Click*");
            magazine.IsEmpty = true;
            magazine.CurrentState = new Empty();
        }
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