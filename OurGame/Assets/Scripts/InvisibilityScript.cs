using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Make object invisible
        MakeInvisible();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        //Make object visible when it collides with light
        if (collision.CompareTag("Light"))
        {
            MakeVisible();
        }
    }

    public void MakeVisible()
    {
        GetComponent<Renderer>().enabled = true;

    }

    public void MakeInvisible()
    {
        GetComponent<Renderer>().enabled = false;

    }
}
