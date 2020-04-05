using System;
using System.Collections;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int Size = 0;
    public int CurrentBullets = 0;
    public float ReloadDuration = 0f;
    public float Elapsed = 0f;

    public IMagazineState CurrentState;

    public void Shoot()
    {
        CurrentState.Shoot(this);
    }

    public IEnumerator Reload()
    {
        return CurrentState.Reload(this);
    }

}