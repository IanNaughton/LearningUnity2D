﻿using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public WeaponHolder weaponHolder;
    public Animator playerAnimator;
    public AudioSource playerAudio;

    public float runSpeed = 40f;
    public float horizontalMovement = 0f;
    public bool jump = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        PlayJumpSound();
        controller.Move(horizontalMovement * runSpeed * Time.fixedDeltaTime, false, jump);
        playerAnimator.SetBool("IsMoving", horizontalMovement != 0);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var crate = collision.gameObject.GetComponent<Crate>();
        if (crate != null)
        {
            weaponHolder.EquipWeapon(crate.WeaponType);
        }
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            DestroyPlayer();
        }
    }

    private void PlayJumpSound()
    {
        if (jump)
        {
            playerAudio.Play();
        }
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}