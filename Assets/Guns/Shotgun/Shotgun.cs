public class Shotgun : GunBase
{
    public float NumberOfBullets = 0f;

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
            bullet.Damage = Damage;
        }
        base.PlayShootSound();
    }
}