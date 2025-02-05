using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    Transform playerPosition;
    public Vector3 offset;
    public float damping;

    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        Vector3 newCamPosition = new Vector3(playerPosition.position.x + offset.x, playerPosition.position.y + offset.y, offset.z);
        transform.position = Vector3.Lerp(transform.position, newCamPosition, damping * Time.deltaTime);
    }
}
