using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_control : MonoBehaviour
{
    public float health;
    
  
    void Update()
    {
        if (health <= 0)
        {
            Game_Cont cont = GameObject.FindGameObjectWithTag("Cont").GetComponent<Game_Cont>();
            cont.GetItem(transform);
            Destroy(gameObject);
        }
    }
}
