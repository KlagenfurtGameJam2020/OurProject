using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool isGrounded = false;
    public Animator animator;
    public float moveSpeed = 5f;
    public float jumpSpeed = 10f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.position = RespawnScript.currentCheckpoint.position;

    }


    void Update()
    {
        /* Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
         transform.position += Move * Time.deltaTime * moveSpeed;
        */

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

}
