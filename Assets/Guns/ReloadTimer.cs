using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTimer : MonoBehaviour
{
    public float Elapsed = 0f;
    public float WaitTime = 0f;
    public bool IsDone = true;

    public void Reset()
    {
        IsDone = false;
        Elapsed = 0f;
    }
    public IEnumerator StartTimerAsCoroutine()
    {
        while (Elapsed <= WaitTime)
        {
            // Add the amount of time that has passed since 
            // the last3 time this was called
            Elapsed += Time.deltaTime;
            yield return null;
        }
        IsDone = true;
    }
}
