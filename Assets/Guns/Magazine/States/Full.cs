using System;
using System.Collections;
using UnityEngine;


public class Full : MonoBehaviour, IMagazineState
{
    public void Shoot(Magazine magazine)
    {
        if (magazine.CurrentBullets > 1)
        {
            magazine.CurrentBullets -= 1;
        }
        else
        {
            magazine.CurrentState = new Empty();
        }

    }

    public IEnumerator Reload(Magazine magazine)
    {
        magazine.CurrentState = new Reloading();
        yield return null;

    }

}