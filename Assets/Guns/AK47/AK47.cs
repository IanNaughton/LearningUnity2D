using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour
{
  public Transform FirePoint;
  public GameObject BulletPrefab;
  public FireTimer FireRateTimer;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButton("Fire1"))
    {
      if (FireRateTimer.IsDone)
      {
        FireRateTimer.Reset();
        StartCoroutine(FireRateTimer.StartTimerAsCoroutine());
        Shoot();
      }
    }
  }

  void Shoot()
  {
    // Shoosting logic
    Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
  }


}
