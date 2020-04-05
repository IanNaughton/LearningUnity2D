using System;
using System.Collections;
using UnityEngine;


public class Empty : MonoBehaviour, IMagazineState
{
    public void Shoot(Magazine magazine)
    {
        Debug.Log("Click");
    }

    public IEnumerator Reload(Magazine magazine)
    {
        magazine.CurrentState = new Reloading();
        yield return null;
    }

}