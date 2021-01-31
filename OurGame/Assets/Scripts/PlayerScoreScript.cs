using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreScript : MonoBehaviour
{
    //This List contains the scores of all previous levels. 
    public static List<float> allScores;

    public int enemiesTotal;
    public int enemiesAlive;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        if(allScores == null)
        {
            allScores = new List<float>();
        }

        StartCoroutine(CountInitialNumberOfEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator CountInitialNumberOfEnemies()
    {
        yield return new WaitForSeconds(0.2f);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemiesTotal = enemies.Length;
        enemiesAlive = enemies.Length;

    }

    int CalculateEnemiesAlive()
    {
        Debug.Log("Calculate Enemies alive!");


        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemiesAlive = enemies.Length;

        return enemiesAlive;

    }


    public float CalculateScore()
    {

        Debug.Log("Calculate Score!");

        if (enemiesTotal != 0)
        {
            score = CalculateEnemiesAlive() / enemiesTotal;
        }
        else
        {
            score = 1;
        }

        return score;
    }

    public void AddScoreToList()
    {
        Debug.Log("Adding score to list");
        allScores.Add(CalculateScore());
    }
}
