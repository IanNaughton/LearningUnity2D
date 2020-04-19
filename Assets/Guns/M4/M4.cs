using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4 : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public Chamber Chamber;
    public Magazine Clip;
    public float BulletSpeed = 0f;
    public float BulletRange = 0f;
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

    void CreateBullet()
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

    IEnumerator Reload()
    {
        return Clip.Reload();
    }
}
