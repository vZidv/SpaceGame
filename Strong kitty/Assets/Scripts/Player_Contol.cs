using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Contol : MonoBehaviour
{
    public float health;
    public float turbo;
    public int Level;

    private float healthStart;
    private float turboStart;
    [Header("")]
    public float speed;
    public float SpeedBoost;
    private float startSpeed;
    float hor, ver;
    bool isDead = false;
    void Start()
    {
        healthStart = health;
        startSpeed = speed;
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && turbo > 0)
        {
            speed = SpeedBoost;
            turbo -= Time.deltaTime;
        }
        else
        {
            speed = startSpeed;
            if(turbo < 10)
            turbo += Time.deltaTime/2;
        }

        hor = (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        ver = (Input.GetAxis("Vertical") * speed * Time.deltaTime);

        Vector3 pos = new Vector3(hor, ver, 0);
        transform.position += pos;
        if (health > healthStart)
            health = healthStart;
        else if (health <= 0 && !isDead)
        {
            Destroy(gameObject);
           // isDead = true;
        }

    }
    public void GetDamage(float damage) => health -= damage;
}
