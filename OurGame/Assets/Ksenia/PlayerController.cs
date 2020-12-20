using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    bool isJumping = false;
    bool isRunning = false;
    bool isIdle = false;

    public float moveSpeed;
    public float jumpPower;
    private SpriteRenderer playerSpriteRenderer;
  
    private Rigidbody2D rb;

    bool isGrounded = false;

    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
          rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        playerAnimator.SetBool("isJumping", isJumping);
        playerAnimator.SetBool("isMoing", isRunning);
        playerAnimator.SetBool("isIdle", isIdle);
        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += Move * Time.deltaTime * moveSpeed;
        if (Move.x != 0)
        {
            isIdle = false;
            if (isGrounded == true)
            {
                isRunning = true;
                isJumping = false;
            }

            else
            {
                isRunning = false;
                isJumping = true;
            }
        }

        else
        {
            if (isGrounded == true)
            {
                isIdle = true;
                isJumping = false;
                isRunning = false;
            }
        }
            Jump();

        if (Move.x > 0f)
        {
            playerSpriteRenderer.flipX = false;
        }
        else if (Move.x < 0f)
        {
            playerSpriteRenderer.flipX = true;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isJumping = true;
            isRunning = false;
            isIdle = false; 

            rb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }
}
