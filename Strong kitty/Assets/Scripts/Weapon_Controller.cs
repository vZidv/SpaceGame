﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Controller : MonoBehaviour
{
    [Header("Settings")]
    public float damage;
    public Transform[] ShootPoints;
    public float timeForFireStart;
    public float scatter = 0;
    public GameObject bulletPrefab;
    //Dont touch
    float timeForFire = 0;

    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeForFire = timeForFireStart;
    }
    public void Update()
    {
       
        if(timeForFire >0)
         timeForFire -= Time.deltaTime;
    }
    public void Shoot()
    {
        if (timeForFire <= 0)
        {
            timeForFire = timeForFireStart;
            for (int i = 0; i < ShootPoints.Length; i++)
            {
                if (scatter == 0)
                {
                    GameObject bullet = Instantiate(bulletPrefab, ShootPoints[i].transform.position, ShootPoints[i].transform.rotation);
                    bullet.GetComponent<Bullet>().Damage = damage;
                }
                else
                {
                    float scatterNow = Random.Range(-scatter, scatter);
                    Quaternion angle = player.rotation;
                    angle.z += scatterNow;
                    GameObject bullet = Instantiate(bulletPrefab, ShootPoints[i].transform.position, angle);
                    bullet.GetComponent<Bullet>().Damage = damage;
                }
            }       
        }
        else
            return;
        
    }
   
}