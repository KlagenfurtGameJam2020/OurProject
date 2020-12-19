using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyScript : MonoBehaviour { 

    //The damaged caused to the enemy
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

        //Debug.Log("Something collided with enemy");

        //If Enemy or projectile touches Player, the player loses 1 health (and dies)

        if (collision.CompareTag("Enemy"))
        {
           // Debug.Log("Enemy got hit!");

            //Subtract enemy health here

            collision.gameObject.GetComponent<EnemyHealthScript>().DecreaseHealth(damage);
        }
    }
}
