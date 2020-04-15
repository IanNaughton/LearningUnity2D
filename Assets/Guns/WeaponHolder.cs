using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
  int SelectedWeapon = 0;
  int WeaponCount => transform.childCount - 1;
  // Start is called before the first frame update
  void Start()
  {
    SetActiveWeapon();
  }

  // Update is called once per frame
  void Update()
  {
    HandlePlayerInput();
  }

  void SetActiveWeapon()
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

  void HandlePlayerInput()
  {
    if (Input.GetButtonDown("SwapWeapon"))
    {
        CycleWeapons();
        SetActiveWeapon();
    }
  }

  void CycleWeapons()
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
