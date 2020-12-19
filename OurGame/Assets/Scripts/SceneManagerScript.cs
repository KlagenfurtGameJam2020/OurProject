using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        LightMovement fairy = FindObjectOfType<LightMovement>();
        float tempFairySpeed = fairy.rotateSpeed;
        fairy.rotateSpeed = 0;

        MusicScript music = FindObjectOfType<MusicScript>();

        music.StopNormal();
        music.StopSad();
        FindObjectOfType<MusicScript>().PlayVictory();

        yield return new WaitForSeconds(8f);

        player.moveSpeed = tempPlayerMoveSpeed;
        fairy.rotateSpeed = (int)tempFairySpeed;
        //Load new Scene
        SceneManager.LoadScene(nextScene);
    }

}
