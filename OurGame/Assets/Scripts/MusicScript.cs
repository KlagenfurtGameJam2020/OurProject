using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{

    public AudioSource normalMusic;
    public AudioSource sadMusic;
    public AudioSource victoryMusic;



    //Check if this object was already spawned
   // public static bool isSpawned;

    // Start is called before the first frame update
    void Awake()
    {
        /*if (!isSpawned)
        {
            DontDestroyOnLoad(gameObject);
            isSpawned = true;
        }
        else
        {
            Destroy(gameObject);
        }*/
    }

     void Start()
    {
        PlayNormal();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StopNormal();
            PlaySad();
        }

    }



    public void PlayNormal()
    {
        if (!normalMusic.isPlaying)
            normalMusic.PlayDelayed(0.2f);
    }

    public void PlaySad()
    {
        if (!sadMusic.isPlaying)
            sadMusic.PlayDelayed(0.2f);
    }

    public void StopNormal()
    {
        normalMusic.Stop();
    }

    public void StopSad()
    {
        sadMusic.Stop();
    }

    public void PlayVictory()
    {
        victoryMusic.Play();
    }

}
