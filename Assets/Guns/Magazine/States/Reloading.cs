using System;
using System.Collections;
using UnityEngine;


public class Reloading : MonoBehaviour, IMagazineState
{
    public void Shoot(Magazine magazine)
    {
        Debug.Log("(Reloading)");
    }

    public IEnumerator Reload(Magazine magazine)
    {
        while (magazine.Elapsed < magazine.ReloadDuration)
        {
            magazine.Elapsed += Time.deltaTime;
            yield return null;
        }
        magazine.Elapsed = 0;
        magazine.CurrentBullets = magazine.Size;
        magazine.CurrentState = new Full();
    }

}