using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerScript : MonoBehaviour
{
    //Amount of health player loses upon collide
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Something collided with enemy");

        //If Enemy or projectile touches Player, the player loses 1 health (and dies)

        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("Player collided with enemy");

            //Subtract player health here

            collision.gameObject.GetComponent<PlayerHealthScript>().DecreaseHealth(damage);
        }
    }
}
