using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
   // public Rigidbody2D rb;
    public int rotateSpeed;

    
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        transform.RotateAround(transform.parent.transform.position, new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);
    }
}
