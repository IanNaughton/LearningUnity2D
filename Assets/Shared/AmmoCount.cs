using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public WeaponHolder weaponHolder;
    public Text ammo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponHolder != null)
        {
            var currentGunObject = weaponHolder.transform.GetChild(weaponHolder.SelectedWeapon);
            var currentGun = currentGunObject.GetComponent<GunBase>();
            ammo.text = currentGun.Clip.CurrentBullets.ToString();
        }
        else
        {
            ammo.text = "--";
        }
        
    }
}
