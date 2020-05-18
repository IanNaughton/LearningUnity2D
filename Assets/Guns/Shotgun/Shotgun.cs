﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : GunBase
{
    public float NumberOfBullets = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    public override void Shoot()
    {
        if (Clip.IsEmpty)
        {
            StartCoroutine(Clip.Reload());
        }

        if (!Chamber.IsFiring &&
            !Clip.IsEmpty &&
            !Clip.IsReloading)
        {
            StartCoroutine(Chamber.Shoot(Clip));
            CreateBullet();
        }
    }

    public override void CreateBullet()
    {
        for (int i = 0; i <= NumberOfBullets; i++)
        {
            // Shoosting logic
            var bulletPrefabInstance = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            var bullet = bulletPrefabInstance.GetComponent<Bullet>();

            // Set bullet attributes unique to this gun
            bullet.gameObject.layer = gameObject.layer;
            bullet.Speed = BulletSpeed;
            bullet.Range = BulletRange;
            bullet.RotationMax = BulletRotationMax;
            bullet.RotationMin = BulletRotationMin;
        }
    }
}
