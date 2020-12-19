using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;

    //Time before the projectile is destroyed. Set to <= 0 if it shouldnt be destroyed
    public float timeUntilDestroy;

    // Start is called before the first frame update
    void Start()
    {
        if(timeUntilDestroy > 0)
        Invoke("DestroyProjectile", timeUntilDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

      
        //Destroy projectile when it collides with something(but not an enemy!!)

        if (!collision.CompareTag("Enemy"))
        {
            DestroyProjectile();
        }
    }
}
