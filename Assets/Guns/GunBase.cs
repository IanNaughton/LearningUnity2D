using UnityEngine;

public class GunBase : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public Chamber Chamber;
    public Magazine Clip;
    public float BulletSpeed = 0f;
    public float BulletRange = 0f;
    public float BulletRotationMax = 0f;
    public float BulletRotationMin = 0f;
    public float Range = 0f;
    public float Damage = 0f;

    private ObjectPool _objectPool;

    public virtual void Start()
    {
        _objectPool = ObjectPool.Instance;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //if (Input.GetButton("Fire1"))
        //{
        //    Shoot();
        //}
        //if (Input.GetButton("Reload"))
        //{
        //    Reload();
        //}
    }

    public virtual void Shoot()
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

    public virtual void CreateBullet()
    {
        // Shoosting logic
        var bulletPrefabInstance = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        //var bulletPrefabInstance = _objectPool.SpawnObject("Bullet", FirePoint.position, FirePoint.rotation);
        var bullet = bulletPrefabInstance.GetComponent<Bullet>();

        // Set bullet attributes unique to this gun
        bullet.gameObject.layer = gameObject.layer;
        bullet.Speed = BulletSpeed;
        bullet.Range = BulletRange;
        bullet.RotationMax = BulletRotationMax;
        bullet.RotationMin = BulletRotationMin;
        bullet.Damage = Damage;
    }

    public virtual void Reload()
    {
        StartCoroutine(Clip.Reload());
    }
}