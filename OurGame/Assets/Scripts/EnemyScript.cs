using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

   
    public float moveSpeed;


    //The two points between which the enemy moves
    public float point1;
    public float point2;

    public Vector2[] moves;

    public Vector2 lastPoint;

    //Shows if the enemy moves(flies) vertically instead of horizontally
    public bool movesVertical;


    //Direction where enemy moves.  -1...left,   +1...right
    private int dir;


    private int moveCount;

    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {

        myRB = GetComponent<Rigidbody2D>();

        dir = -1;

        moveCount = 0;

        lastPoint = transform.position;

       // float start = Random.Range(0, 5);

        //InvokeRepeating("SwitchDirection",0, switchTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Move horizontally
        /* if (!movesVertical)
         {
             myRB.velocity = new Vector2(dir * moveSpeed, myRB.velocity.y);


             //Switch direction
             if (dir == -1 && transform.position.x < point1 || dir == 1 && transform.position.x > point2)
             {
                 dir *= -1;
             }
         }
         else
         {
             //Move vertically
             myRB.velocity = new Vector2(0, dir * moveSpeed);


             //Switch direction
             if (dir == -1 && transform.position.y < point1 || dir == 1 && transform.position.y > point2)
             {
                 dir *= -1;
             }

         }*/

        
            //Vector2 direction = new Vector2(point1.x - transform.position.x, point1.y - transform.position.y);

            Vector2 direction = moves[moveCount].normalized;

            myRB.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

        Vector2 difference = new Vector2(transform.position.x - lastPoint.x, transform.position.y - lastPoint.y);

        if (difference.magnitude >= moves[moveCount].magnitude)
        {
            moveCount++;

            lastPoint = transform.position;


            //Return to first move at the end of array
            if (moveCount == moves.Length)
            {
                moveCount = 0;
            }
        }

        


    }


    void SwitchDirection()
    {
        Debug.Log("Enemy switches direction.");
        //myRB.velocity = new Vector2(dir * moveSpeed, 0);

        //myRB.AddForce(new Vector2(dir * moveSpeed, 0));

        //Switch direction
        dir *= -1;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Something collided with enemy");

        //If Enemy touches Player, the player loses 1 health (and dies)

        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("Player collided with enemy");

            //Subtract player health here

            collision.gameObject.GetComponent<PlayerHealthScript>().DecreaseHealth();
        }
    }



}
