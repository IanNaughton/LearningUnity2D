using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ImpactEffect;
    public float Speed = 20f;
    public float RotationMax = 0f;
    public float RotationMin = 0f;
    public Rigidbody2D rb;
    private Vector3 StartPosition;
    public float DistanceTraveled = 0f;
    public float Range = 0f;
    public float Damage = 0f;

    // Special bullet attributes
    public bool IsCriticalHit = false;

    private void Start()
    {
        StartPosition = transform.position;
        MoveBullet();
        PointBulletInMovementDirection();
    }

    private void MoveBullet()
    {
        var recoil = Random.Range(RotationMin, RotationMax);
        rb.velocity = new Vector2(transform.right.x * Speed, transform.up.y * recoil);
    }

    private void PointBulletInMovementDirection()
    {
        // This is basically stolen code because I didn't pay attention in
        // geometry and don't remember my trig functions. I'm a dumb-dumb.
        // TODO: GIT GUD AT MATH
        var angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Update()
    {
        CheckDistanceTraveled();
    }

    private void CheckDistanceTraveled()
    {
        DistanceTraveled += Vector3.Distance(StartPosition, transform.position);
        if (DistanceTraveled >= Range)
        {
            // Before we blow away the bullet instance, create an instance of the
            // impact effect.
            Instantiate(ImpactEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Gotta make sure that bullets don't end eachother by colliding!      
        var hitObject = hitInfo.gameObject.GetComponent<IShootable>();
        if (hitObject != null)
        {
            Debug.Log(hitInfo.name);
            Instantiate(ImpactEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}