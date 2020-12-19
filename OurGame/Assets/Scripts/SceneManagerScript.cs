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
        MusicScript music = FindObjectOfType<MusicScript>();

        music.StopNormal();
        music.StopSad();
        FindObjectOfType<MusicScript>().PlayVictory();

        yield return new WaitForSeconds(8f);


        //Load new Scene
        SceneManager.LoadScene(nextScene);
    }

}
