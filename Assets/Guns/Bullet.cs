using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 20f;
    public float RotationMax = 0f;
    public float RotationMin = 0f;
    public Rigidbody2D rb;

    void Start()
    {
        var recoil = Random.Range(RotationMin, RotationMax);
        rb.velocity = new Vector2(transform.right.x * Speed, transform.up.y * recoil);

        // This is basically stolen code because I didn't pay attention in 
        // geometry and don't remember my trig functions. I'm a dumb-dumb.
        var angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        if (hitInfo.name != "Boolet(Clone)")
        {
            Destroy(gameObject);
        }
    }
}