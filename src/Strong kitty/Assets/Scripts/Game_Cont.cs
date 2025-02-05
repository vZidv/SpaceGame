using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Cont : MonoBehaviour
{
  public GameObject[] cristals;
    public GameObject planet;
    public Sprite[] planetsM;
    public GameObject[] enemies;

    GameObject player;
    public float timeSpawnEnemies;
    float startTimeSpawnEnemies;
    private void Start()
    {
        startTimeSpawnEnemies = timeSpawnEnemies;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void GetItem(Transform transformP)
    {
        int rand = Random.Range(0, 100);
        int numberItem = 0;
        if (rand <= 40)
            numberItem = 0;
        else if (rand > 40 && rand <= 60)
            numberItem = 1;
        else if (rand > 60 && rand <= 70)
            numberItem = 2;
        else if(rand > 70 && rand <= 90)
            numberItem = 3;

        Instantiate(cristals[numberItem], transformP.position, transformP.rotation);
    }
    private void FixedUpdate()
    {
        if(timeSpawnEnemies <= 0 )
        {
            int rand = Random.Range(0, 6);

            int randRange = Random.Range(15, 20);
            if(rand > 0 && rand <= 3)
            {
                rand = Random.Range(0, 2);
                Instantiate(enemies[rand], player.transform.position + new Vector3(0, randRange, 0), player.transform.rotation);
            }
            else if (rand > 3 && rand <= 6)
            {
                rand = Random.Range(0, 2);
                Instantiate(enemies[rand], player.transform.position + new Vector3(randRange,0, 0), player.transform.rotation);
            }
            timeSpawnEnemies = startTimeSpawnEnemies;
        }
        else
        {
            timeSpawnEnemies -= Time.deltaTime;
        }
    }
    public Sprite ChangePlanet()
    {
        int rand = Random.Range(0, planetsM.Length -1 );
        return planetsM[rand];
    }
}
