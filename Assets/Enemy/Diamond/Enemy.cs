﻿using UnityEngine;

public class Enemy : MonoBehaviour, IShootable
{
    public float Speed;
    public Rigidbody2D EnemyBody;
    public Collider2D EnemyBodyCollider;
    public GameObject RightWallCollider;
    public GameObject LeftWallCollider;
    public float Hitpoints;
    public GameObject DamageNumberPrefab;
    public Transform DamageNumberSpawnPoint;
    public GameObject DeathEffect;

    private void Start()
    {
    }

    private void Update()
    {
        // move the enemy
        EnemyBody.velocity = new Vector2(10f * Speed, EnemyBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>() != null)
        {
            TakeDamage(collision.gameObject);
        }
        if (collision.gameObject.name == "Destroyer")
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage(GameObject weapon)
    {
        var bullet = weapon.GetComponent<Bullet>();
        ShowDamageNumber(bullet);
        ApplyHitpoints(bullet.Damage);
    }

    private void ShowDamageNumber(Bullet bullet)
    {
        var damageNumberPrefab = Instantiate(DamageNumberPrefab, DamageNumberSpawnPoint.position, DamageNumberSpawnPoint.rotation);
        var damageNumber = damageNumberPrefab.GetComponent<DamageNumber>();
        damageNumber.DamageAmount = bullet.Damage.ToString();
        if (bullet.IsCriticalHit)
        {
            damageNumber.DamageText.fontStyle = FontStyle.Bold;
            damageNumber.DamageText.color = Color.yellow;
            SoundManager.Instance.PlayCriticalHit();
        }
    }

    private void ApplyHitpoints(float damageAmount)
    {
        Hitpoints = Hitpoints - damageAmount;
        if (Hitpoints <= 0)
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}