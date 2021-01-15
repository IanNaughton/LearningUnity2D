using System;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject WeaponNamePrefab;
    public Transform WeaponNameSpawnPoint;
    public Type WeaponType;
    public GameState gameState;
    public AudioSource crateAudio;
    public static int lastWeaponIndex;

    private List<Type> WeaponTypes => new List<Type> {
        typeof(AK47),
        typeof(M4),
        typeof(Shotgun)
    };

    private void Start()
    {
        var weaponIndex = UnityEngine.Random.Range(0, WeaponTypes.Count);

        // We don't want to spawn two of the same weapon back-to-back
        while (weaponIndex == lastWeaponIndex)
        {
            weaponIndex = UnityEngine.Random.Range(0, WeaponTypes.Count);
        }
        WeaponType = WeaponTypes[weaponIndex];
        lastWeaponIndex = weaponIndex;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            var weaponNamePrefab = Instantiate(WeaponNamePrefab, WeaponNameSpawnPoint.position, WeaponNameSpawnPoint.rotation);
            var damageNumber = weaponNamePrefab.GetComponent<DamageNumber>();
            damageNumber.DamageAmount = WeaponType.ToString();
            damageNumber.RightDriftMax = 0;
            damageNumber.LeftDriftMax = 0;
            damageNumber.DamageText.fontSize = 320;
            gameState.CrateCollected();
            PlayCrateSound();
            Destroy(gameObject, crateAudio.clip.length);
        }
    }

    private void PlayCrateSound()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        crateAudio.Play();
    }
}