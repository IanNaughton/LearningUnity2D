using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{

    public float Speed;
    public Rigidbody2D EnemyBody;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move the enemy 
        EnemyBody.velocity = new Vector2(10f * Speed, EnemyBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Are we getting hit by a boolet?!
        if (collision.gameObject.tag == Constants.Tags.PROJECTILE)
        {
            Debug.Log($"colliding with: {collision.gameObject.tag}");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
