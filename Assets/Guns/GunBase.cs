using UnityEngine;

public class GunBase : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public Chamber Chamber;
    public Magazine Clip;
    public BulletPipeline BulletPipeline;
    public AudioSource shootAudioSource;
    public AudioSource reloadAudioSource;
    public float BulletSpeed = 0f;
    public float BulletRange = 0f;
    public float BulletRotationMax = 0f;
    public float BulletRotationMin = 0f;
    public float Range = 0f;
    public float Damage = 0f;

    public virtual void Shoot()
    {
        if (Clip.IsEmpty)
        {
            PlayReloadSound();
            StartCoroutine(Clip.Reload());
        }

        if (!Chamber.IsFiring &&
            !Clip.IsEmpty &&
            !Clip.IsReloading)
        {
            StartCoroutine(Chamber.Shoot(Clip));
            CreateBullet();
            PlayShootSound();
        }
    }

    public virtual void CreateBullet()
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
        bullet.Damage = Damage;

        // Apply any bullet modifiers
        BulletPipeline.Fire(bullet);
    }

    public virtual void PlayShootSound()
    {
        shootAudioSource.Play();
    }

    public virtual void PlayReloadSound()
    {
        if (!Clip.IsReloading)
        {
            reloadAudioSource.Play();

        }
    }

    public virtual void Reload()
    {
        PlayReloadSound();
        StartCoroutine(Clip.Reload());
    }
}