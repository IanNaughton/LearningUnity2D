using System.Collections;
using UnityEngine;

public class PartiallyFull : IMagazineState
{
    public void Init(Magazine magazine)
    {
        magazine.IsEmpty = false;
        magazine.IsReloading = false;
        magazine.CurrentState = new Full();
    }

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
        if (!magazine.IsReloading)
        {
            magazine.IsReloading = true;
            yield return magazine.ReloadBar.Reload();
            magazine.CurrentBullets = magazine.Size;
            magazine.IsEmpty = false;
            magazine.CurrentState = new Full();
            magazine.IsReloading = false;
        }
    }
}