using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public FireTimer FireRateTimer;
    public Magazine BananaCleep;
    public float BulletSpeed = 0f;

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
        if (Input.GetButton("Reload"))
        {
            Reload();
        }


    }

    void Shoot()
    {
        CreateBullet();
        BananaCleep.Shoot();
    }

    void CreateBullet()
    {
        // Shoosting logic
        var bulletPrefabInstance = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        var bullet = bulletPrefabInstance.GetComponent<Bullet>();
        bullet.speed = BulletSpeed;
    }

    IEnumerator Reload()
    {
        return BananaCleep.Reload();
    }

}
