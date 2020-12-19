using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    //Checks if the player has already activated the checkpoint
    private bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Checkpoint collided with player");

        //If player enters checkpoint, save checkpoint in player script
        if (!isActivated && collision.CompareTag("Player"))
        {

            Debug.Log("Activate Checkpoint");

            RespawnScript.currentCheckpoint = gameObject.transform;

            isActivated = true;
        }
    }
}
