using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController2D controller;
    private float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump;
    bool crouch;
    public Animator animator;

    private void Update()
    {

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("crouch"))
        {
            crouch = true;
            animator.SetBool("IsCrouch", true);
        }
        else if (Input.GetButtonUp("crouch"))
        {
            crouch = false;
            animator.SetBool("IsCrouch", false);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}


