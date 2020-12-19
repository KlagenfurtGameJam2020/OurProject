using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScript : MonoBehaviour
{

    public static Transform currentCheckpoint;



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RespawnPlayer()
    {
        //Reload Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //Respawn player at checkpoint

        StartCoroutine(SetPlayerPosition());
            }


    IEnumerator SetPlayerPosition()
    {
        yield return new WaitForSeconds(0.2f);
//        FindObjectOfType<DominikPlayerScript>().GetComponent<Transform>().position = currentCheckpoint.position;

    }
}
