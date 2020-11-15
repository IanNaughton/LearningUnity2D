using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Magazine : MonoBehaviour
{
    public int Size = 0;
    public int CurrentBullets = 0;
    public float ReloadDuration = 0f;
    public bool IsReloading = false;
    public bool IsEmpty = false;
    public ReloadBar ReloadBar;
    public IMagazineState CurrentState;

    private Magazine()
    {
        CurrentState = new Full();
    }

    public void OnEnable()
    {
        CurrentState.Init(this);
    }

    public void Shoot()
    {
        CurrentState.Shoot(this);
    }

    public IEnumerator Reload()
    {
        return CurrentState.Reload(this);
    }
}