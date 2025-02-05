using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float health;
    [Header("")]    
    public float speed;
    private float speedStart;
    public float speedRotation;
    public float distanceStay; // Дистанция на которой остановится корабль
    [Header("Weapon")]
    public GameObject Weapon;
    public float rangeAttack; //Дистанция для атаки    

    GameObject player;
    Weapon_Controller weapon;
    void Start()
    {
        speedStart = speed;
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = Weapon.GetComponent<Weapon_Controller>();
    }


    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        #region Rotation
        Vector3 player_Pose = player.transform.position;

        player_Pose -= transform.position;
        float rotate = Mathf.Atan2(player_Pose.y, player_Pose.x) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rotate - 90), speedRotation * Time.deltaTime);
        #endregion

        var distance = transform.position - player.transform.position;

        if (distance.magnitude <= rangeAttack)
            weapon.Shoot();
        if (distance.magnitude <= distanceStay)
            speed = 0;
        else
            speed = speedStart;

        if (health <= 0)
        {
            Game_Cont cont = GameObject.FindGameObjectWithTag("Cont").GetComponent<Game_Cont>();
            cont.GetItem(transform);
            Destroy(gameObject);
        }
        
    }
    public void GetHit(float damage)
    {
        health -= damage;
    }
}
