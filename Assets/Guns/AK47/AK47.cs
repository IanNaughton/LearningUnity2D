using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public Chamber Chamber;
    public Magazine BananaCleep;
    public float BulletSpeed = 0f;
    public float BulletRotationMax = 0f;
    public float BulletRotationMin = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (BananaCleep.IsEmpty)
        {
            StartCoroutine(BananaCleep.Reload());
        }

        if (!Chamber.IsFiring &&
            !BananaCleep.IsEmpty &&
            !BananaCleep.IsReloading)
        {
            StartCoroutine(Chamber.Shoot(BananaCleep));
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        // Shoosting logic
        var bulletPrefabInstance = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        var bullet = bulletPrefabInstance.GetComponent<Bullet>();

        // Set bullet attributes unique to this gun
        bullet.gameObject.layer = gameObject.layer;
        bullet.Speed = BulletSpeed;
        bullet.RotationMax = BulletRotationMax;
        bullet.RotationMin = BulletRotationMin;
    }

    IEnumerator Reload()
    {
        return BananaCleep.Reload();
    }

}
