using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject prefab;
    public bool isActiv = false;

    public Transform[] points;
    public Transform pointC;
    Game_Cont cont;
    private void Start()
    {
        cont = GameObject.FindGameObjectWithTag("Cont").GetComponent<Game_Cont>();
        float rand = Random.Range(0, 100);
        
        if (rand <= 40f)
        {
             
            GameObject planet = Instantiate(cont.planet, pointC.transform.position, pointC.transform.rotation);
            planet.GetComponent<SpriteRenderer>().sprite = cont.ChangePlanet();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && !isActiv)
        {
            
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] != null)
                {
                    
                    GameObject backGround = Instantiate(prefab, points[i].transform.position, points[i].transform.rotation);
                    BackGround bg = backGround.GetComponent<BackGround>();

                    int rand = Random.Range(0, 110);
                    int rand2 = 1;
                    if (rand > 0 && rand <= 50)
                    {
                        spaw(rand2, 0, points[i]);
                    }
                    else if (rand > 50 && rand <= 65)
                    {
                        spaw(rand2, 1, points[i]); ;
                    }
                    else if (rand > 65 && rand <= 80)
                    {
                        spaw(rand2, 2, points[i]);
                    }


                    bg.isActiv = false;
                }
            }
            isActiv = true;
        }
    }
    void spaw(int numbersRange, int numberOfMass,Transform transformP) {
        for (int i = 0; i < numbersRange; i++)
        {
            if (transformP != null && numbersRange != null && numberOfMass != null)
                try
                {
                    Instantiate(cont.enemies[numberOfMass], transformP.position, transformP.rotation);
                }
                catch
                {
                    cont.timeSpawnEnemies = 0;
                    return;
                }
  
                    
        }
    }
}
