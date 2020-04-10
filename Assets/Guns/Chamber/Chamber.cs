using System.Collections;
using UnityEngine;

public class Chamber : MonoBehaviour
{
    public float FireDuration = 0f;
    public bool IsFiring = false;

    public IEnumerator Shoot(Magazine magazine) 
    {
      IsFiring = true;
      yield return new WaitForSeconds(FireDuration);
      magazine.Shoot();
      IsFiring = false;
    }
}