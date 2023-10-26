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
    {;
        Debug.Log("Jumped");
        jump = true;

        animator.SetBool("IsJumping?", true);
    }

    public void OnLanding()
    {
<<<<<<< HEAD
        Debug.Log("Landed");
        // Set the "IsJumping?" boolean parameter in the Animator to false.
=======
>>>>>>> parent of fbd0fbe (Commenting)
        animator.SetBool("IsJumping?", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
