using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
   // public Rigidbody2D rb;
    public float rotateSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(transform.parent.transform.position, new Vector3(0, 0, 1), 40 * Time.deltaTime);
    }
}
