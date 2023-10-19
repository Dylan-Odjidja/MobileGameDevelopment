using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }
    }

    public void Jump()
    {
        jump = true;
        SoundManager.PlaySound("PlayerJump");
        animator.SetBool("IsJumping?", true);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping?", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
