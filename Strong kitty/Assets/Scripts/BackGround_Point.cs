using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Point : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Point"))
            Destroy(col.gameObject);
    }
}
