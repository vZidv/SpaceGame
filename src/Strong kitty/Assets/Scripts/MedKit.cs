using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public int health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Contol player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Contol>();
            player.health += health;
            Destroy(gameObject);
        }
    }
}
