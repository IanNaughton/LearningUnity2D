using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            var weapon = UnityEngine.Random.Range(0, 2);
            var weaponholder = collision.gameObject.GetComponentInChildren<WeaponHolder>();
            weaponholder.EquipWeapon(weapon);
            Destroy(gameObject);
        }
    }
}
