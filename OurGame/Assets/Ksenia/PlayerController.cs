﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    Rigidbody2D rb;
    float xInput;
    bool isGrounded;

    bool isJumping = false;
    bool isRunning = false;
    bool isIdle = false;


    private Animator animator;
    // Start is called before the first frame update

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        xInput = 0.0f;
        rb = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = false;

        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        if (xInput != 0)
        {
            isIdle = false;

            //if the player is on the ground
            if (isGrounded == true)
            {
                isRunning = true;
                isJumping = false;
            }

            //if the player is not on the ground
            else if (isGrounded == false)
            {
                isRunning = false;
                isJumping = true;
            }

            //if xInput is positive, the player moving right
            if (xInput > 0f)
            {
                spriteRenderer.flipX = false;
            }

            //if xInput is negative, the player moving left
            else if (xInput < 0f)
            {
                spriteRenderer.flipX = true;
            }
        }

        //if the player is not giving x input
        else
        {

            if (isGrounded == true)
            {
                isIdle = true;
                isRunning = false;
                isJumping = false;
            }
        }

        //if xInput, then move the charecter = xInput * speed; 
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        if (Input.GetAxis("Jump") > 0f && isGrounded == true)
        {
            //player is jumping
            isJumping = true;
            isRunning = false;
            isIdle = false;

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

        animator.SetBool("isRunning", isRunning); // connect var from Unity and Visual studio
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isIdle", isIdle);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //player takes 1 point of fall damage
            gameObject.GetComponent<PlayerHealth>().ModifyHealth(-1);
        }
    }
}
