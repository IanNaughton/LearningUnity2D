using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject DamageNumberPrefab;
    public Transform DamageNumberSpawnPoint;
    public Type WeaponType;
    private List<Type> WeaponTypes => new List<Type> {
        typeof(AK47),
        typeof(M4),
        typeof(Shotgun)
    };

    private void Start()
    {
        var weaponIndex = UnityEngine.Random.Range(0, WeaponTypes.Count);
        WeaponType = WeaponTypes[weaponIndex];
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            var damageNumberPrefab = Instantiate(DamageNumberPrefab, DamageNumberSpawnPoint.position, DamageNumberSpawnPoint.rotation);
            var damageNumber = damageNumberPrefab.GetComponent<DamageNumber>();
            damageNumber.DamageAmount = WeaponType.ToString();
            damageNumber.RightDriftMax = 0;
            damageNumber.LeftDriftMax = 0;
            Destroy(gameObject);
        }
    }
}
