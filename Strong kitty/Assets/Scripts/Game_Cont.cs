using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Cont : MonoBehaviour
{
  public GameObject[] cristals;
    public GameObject planet;
    public Sprite[] planetsM;

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
        Instantiate(cristals[numberItem], transformP.position, transformP.rotation);
    }
    public Sprite ChangePlanet()
    {
        int rand = Random.Range(0, planetsM.Length -1 );
        return planetsM[rand];
    }
}
