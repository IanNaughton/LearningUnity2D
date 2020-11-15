using System.Collections;
using UnityEngine;

public class Chamber : MonoBehaviour
{
    public float FireDuration = 0f;
    public bool IsFiring = false;

    public void OnEnable()
    {
        IsFiring = false;
    }

    public IEnumerator Shoot(Magazine magazine)
    {
        IsFiring = true;
        magazine.Shoot();
        yield return new WaitForSeconds(FireDuration);
        IsFiring = false;
    }
}