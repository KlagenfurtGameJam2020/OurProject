using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominikPlayerScript : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = currentCheckpoint.position;

        rb = GetComponent<Rigidbody2D>();

        gameObject.transform.position = RespawnScript.currentCheckpoint.position;
       // rb.position = RespawnScript.currentCheckpoint.position;
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, 0);
        }*/
    }



}
