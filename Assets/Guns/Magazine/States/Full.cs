using System;
using System.Collections;
using UnityEngine;

public class Full : IMagazineState
{
    public void Init(Magazine magazine)
    {
        magazine.IsEmpty = false;
        magazine.IsReloading = false;
        magazine.CurrentState = new Full();
    }
    public void Shoot(Magazine magazine)
    {
        if (magazine.CurrentBullets > 1)
        {
            magazine.CurrentBullets -= 1;
        }
        else
        {
            magazine.IsEmpty = true;
            magazine.IsReloading = false;
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