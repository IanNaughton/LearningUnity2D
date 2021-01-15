using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource CriticalHit;

    private void Start()
    {
        Instance = this;
    }

    public void PlayCriticalHit()
    {
        CriticalHit.PlayOneShot(CriticalHit.clip);
    }
}
