using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("GUI Settings")]
    public Joystick joystick;
    [Header("Player Settings")]
    public float runSpeed = 10.0f;
    public float jumpSpeed = 10.0f;
    [Tooltip("The velocity of the player to stop running animation")]
    [Range(2.0f, 10.0f)]
    public float turnAnimation = 5.0f;

    // Player Private Settings
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool canJump = true;

    private void Awake()
    {
        Initialze();
    }

    private void Initialze()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float hMove = joystick.Horizontal * runSpeed;
        float vMove = joystick.Vertical;

        UpdateAnimation();
        FlipPlayer(hMove);
        MovePlayer(hMove);
        Jump(vMove);
    }

    private void CheckJumping()
    {
        if (rb.velocity.y == 0)
            canJump = true;
        else
            canJump = false;
    }

    private void Jump(float vMove)
    {
        CheckJumping();
        if (canJump && vMove > 0)
        {
            rb.AddForce(new Vector2(0.0f, jumpSpeed * Time.deltaTime));
            animator.SetTrigger("jump");

            canJump = false;
        }
    }

    private void MovePlayer(float hMove)
    {
        rb.AddForce(new Vector2(hMove * Time.deltaTime, 0.0f));
    }

    private void FlipPlayer(float hMove)
    {
        if (hMove < 0)
            spriteRenderer.flipX = true;
        else if (hMove > 0)
            spriteRenderer.flipX = false;
    }

    private void UpdateAnimation()
    {
        if (Mathf.Abs(rb.velocity.x) <= turnAnimation)
            animator.SetBool("run", false);
        else
            animator.SetBool("run", true);
    }
}
