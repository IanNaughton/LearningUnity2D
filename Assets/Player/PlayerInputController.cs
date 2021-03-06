﻿using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputController : MonoBehaviour
{
    public Player Player;
    public WeaponHolder WeaponHolder;
    public bool IsShooting = false;

    public void FixedUpdate()
    {
        if (IsShooting)
        {
            WeaponHolder.Use();
        }
    }

    public void OnTest(CallbackContext ctx)
    {
        Debug.Log("It worked!");
    }

    public void OnJump(CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started:
            case InputActionPhase.Performed:
                Player.jump = true;
                break;

            case InputActionPhase.Canceled:
                Player.jump = false;
                break;

            default:
                Player.jump = false;
                break;
        }
    }

    public void OnShoot(CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started:
            case InputActionPhase.Performed:
                IsShooting = true;
                break;

            case InputActionPhase.Canceled:
                IsShooting = false;
                break;

            default:
                IsShooting = false;
                break;
        }
    }

    public void OnReload(CallbackContext ctx)
    {
        WeaponHolder.Reload();
    }

    public void OnCycleWeapons(CallbackContext ctx)
    {
        //if (ctx.phase == InputActionPhase.Performed)
        //{
        //    WeaponHolder.CycleWeapons();
        //}
    }

    public void OnMove(CallbackContext ctx)
    {
        Player.horizontalMovement = ctx.ReadValue<float>();
    }
}