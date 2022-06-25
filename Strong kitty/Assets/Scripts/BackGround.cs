using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject prefab;
    public bool isActiv = false;

    public Transform[] points;
    public Transform pointC;
    private void Start()
    {
        float rand = Random.Range(0, 100);
        
        if (rand <= 40f)
        {
            Game_Cont cont = GameObject.FindGameObjectWithTag("Cont").GetComponent<Game_Cont>();
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
                if (points[i])
                {
                    GameObject backGround = Instantiate(prefab, points[i].transform.position, points[i].transform.rotation);
                    BackGround bg = backGround.GetComponent<BackGround>();
                    bg.isActiv = false;
                }
            }
            isActiv = true;
        }
    }
}
