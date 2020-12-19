using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

   
    public float moveSpeed;


    //Checks how many projectiles the enemy shoots per move
    public int shootCount;

    public Transform projectile;

    public float projectileSpeed;

    //Time between two consecutive shoots
    public float timeBetweenShots;


    //Time Enemy Waits between moves
    public float waitTime;
  

    public Vector2[] moves;

    public Vector2 lastPoint;

   

    private int moveCount;

    Rigidbody2D myRB;


    //Shows if enemy is currently waiting
    private bool isWaiting = false;

    // Start is called before the first frame update
    void Start()
    {

        myRB = GetComponent<Rigidbody2D>();
        moveCount = 0;
        lastPoint = transform.position;

       
     
    }

    // Update is called once per frame
    void Update()
    {
 
        if (!isWaiting)
        {
            Vector2 direction = moves[moveCount].normalized;

            myRB.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);


            Vector2 difference = new Vector2(transform.position.x - lastPoint.x, transform.position.y - lastPoint.y);

            //If a move is finished then wait and then switch to the next move
            if (difference.magnitude >= moves[moveCount].magnitude)
            {
               // Debug.Log("Enemy switches move");

                myRB.velocity = new Vector2(0, 0);

                isWaiting = true;

                StartCoroutine(SwitchMove());

               
            }
        }

    }



    private void ShootProjectile()
    {
      //  Debug.Log("Enemy shoots projectile");

        Transform p = Instantiate(projectile) as Transform;

        p.position = gameObject.transform.position;

        p.GetComponent<Rigidbody2D>().velocity = moves[moveCount].normalized * p.GetComponent<ProjectileScript>().speed;


        //Projectiles has same visibility as Enemy
        p.GetComponent<Renderer>().enabled = GetComponent<Renderer>().enabled;
    }


    //Wait, shoot(optional) and switch to the next move
    IEnumerator SwitchMove()
    {
        //Debug.Log("Enemy switches move");
        //Wait given time

        yield return new WaitForSeconds(waitTime);

        //Shoot projectiles and wait between each shoot
        for(int i = 0; i < shootCount; i++)
        {
           // Debug.Log("Enemy shoots projectile -1");


            ShootProjectile();
            yield return new WaitForSeconds(timeBetweenShots);
        }

        //Set new move
        moveCount++;

        lastPoint = transform.position;


        //Return to first move at the end of array
        if (moveCount == moves.Length)
        {
            moveCount = 0;
        }

        //End waiting

        isWaiting = false;

    }


 



}
