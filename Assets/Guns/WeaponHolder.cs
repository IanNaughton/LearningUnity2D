﻿using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private int SelectedWeapon = 0;
    int WeaponCount => transform.childCount - 1;

    // Start is called before the first frame update
    private void Start()
    {
        SetActiveWeapon();
    }

    // Update is called once per frame
    private void Update()
    {
        // HandlePlayerInput();
    }

    private void SetActiveWeapon()
    {
        // This entire thing feels like a gigantic hack. No type safety
        // and
        var weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(weaponIndex == SelectedWeapon);
            weaponIndex++;
        }
    }

    public void Use()
    {
        var selectedWeapon = transform.GetChild(SelectedWeapon);
        selectedWeapon.GetComponent<GunBase>().Shoot();
    }

    private void CycleWeapons()
    {
        if (SelectedWeapon != WeaponCount)
        {
            SelectedWeapon++;
        }
        else
        {
            SelectedWeapon = 0;
        }
    }
}