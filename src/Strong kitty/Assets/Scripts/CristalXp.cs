using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalXp : MonoBehaviour
{
    public int xp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player_Contol>().Xp += xp;
            Destroy(gameObject);
        }
    }
}
