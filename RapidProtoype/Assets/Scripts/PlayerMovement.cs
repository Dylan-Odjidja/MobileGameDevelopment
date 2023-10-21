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
        // Set the "Speed" parameter in the Animator based on the absolute horizontal movement.
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        // Check the input from the joystick to set the horizontal movement.
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
        // Set the "IsJumping?" boolean parameter in the Animator to true.
        animator.SetBool("IsJumping?", true);
    }

    public void OnLanding()
    {
        // Set the "IsJumping?" boolean parameter in the Animator to false.
        animator.SetBool("IsJumping?", false);
    }

    void FixedUpdate()
    {
        // Move the character using the CharacterController2D with the calculated horizontal movement and jump flag.
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        // Reset the jump flag after the FixedUpdate frame.
        jump = false;
    }
}
