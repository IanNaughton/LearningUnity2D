using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Player Player;
    public WeaponHolder WeaponHolder;

    public void OnTest()
    {
        Debug.Log("It worked!");
    }

    public void OnJump()
    {
        Player.jump = true;
    }

    public void OnShoot()
    {
        WeaponHolder.Use();
    }

    public void OnMove(InputValue value)
    {
        Player.horizontalMovement = value.Get<float>();
    }
}