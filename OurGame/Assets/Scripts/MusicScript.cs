using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    //Music
    public AudioSource normalMusic;
    public AudioSource sadMusic;
    public AudioSource victoryMusic;

    public AudioSource currentMusic;

    //Sound Effects
    public AudioSource runningSound;
    public AudioSource menuClick;



    //Check if this object was already spawned
   // public static bool isSpawned;

    // Start is called before the first frame update
    void Awake()
    {
      /*  if (!isSpawned)
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
        if (sadMusic != null && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScoreScript>().CalculateScore() <= 0.5)
        {
            StopNormal();
            PlaySad();
        }

    }



    public void PlayNormal()
    {
        if (normalMusic != null && !normalMusic.isPlaying)
        {
            normalMusic.PlayDelayed(0.2f);
            currentMusic = normalMusic;
        }
    }

    public void PlaySad()
    {
        if (sadMusic != null && !sadMusic.isPlaying)
        {
            sadMusic.PlayDelayed(0.2f);
            currentMusic = sadMusic;
        }
    }

    public void StopCurrentMusic()
    {
        currentMusic.Stop();
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


    public void PlayMenuClick()
    {
        menuClick.Play();
    }


    public void PlayRunningSound()
    {
        runningSound.Play();
    }


}
