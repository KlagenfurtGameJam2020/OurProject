using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth()
    {
        health--;
        CheckIfDead();
    }

    public void IncreaseHealth()
    {
        health++;
        //CheckIfDead()
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
        CheckIfDead();
    }


    //Checks if player is dead and respawns him
    public void CheckIfDead()
    {
        if(health <= 0)
        {
            FindObjectOfType<RespawnScript>().RespawnPlayer();
        }

    }
}
