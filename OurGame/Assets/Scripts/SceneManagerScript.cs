using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{

    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entered Scene Manager");
            //Calculate score before switching scenes

            FindObjectOfType<PlayerScoreScript>().AddScoreToList();

            //Destroy respawnscript of this level

            Destroy(FindObjectOfType<RespawnScript>());
            RespawnScript.currentCheckpoint = null;


            StartCoroutine(PlayVictorySequence());

            
        }
    }


    IEnumerator PlayVictorySequence()
    {
        //Freeze player and fairy
        PlayerController player = FindObjectOfType<PlayerController>();
        float tempPlayerMoveSpeed = player.moveSpeed;
        player.moveSpeed = 0;

        float tempFairySpeed = 0;
        LightMovement fairy = FindObjectOfType<LightMovement>();
        if (fairy != null)
        {
            tempFairySpeed = fairy.rotateSpeed;
            fairy.rotateSpeed = 0;
        }

        MusicScript music = FindObjectOfType<MusicScript>();

        music.StopCurrentMusic();
       
        FindObjectOfType<MusicScript>().PlayVictory();

        yield return new WaitForSeconds(7f);

        player.moveSpeed = tempPlayerMoveSpeed;

        if(fairy != null) 
        fairy.rotateSpeed = (int)tempFairySpeed;
        //Load new Scene
        SceneManager.LoadScene(nextScene);
    }


   

}
