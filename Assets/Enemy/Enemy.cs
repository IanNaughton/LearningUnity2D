using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D EnemyBody;
    public GameObject RightWallCollider;
    public GameObject LeftWallCollider;
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
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Foreground")
        {
            Speed = Speed * -1;
        }
        if (collision.gameObject.name == "Boolet(Clone)")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Destroyer")
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
