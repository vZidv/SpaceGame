using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Contol : MonoBehaviour
{
    public float health;
    public float turbo;
    public int Level;
    [Header("Xp")]
    public int startXp;
    public int Xp;
    public int stepXp;
    [Header("")]
    private float healthStart;
    private float turboStart;
    [Header("")]
    public float speed;
    public float SpeedBoost;
    private float startSpeed;
    float hor, ver;
    bool isDead = false;

    Player_Ui playerUi;
    void Start()
    {
        healthStart = health;
        startSpeed = speed;
        playerUi = GameObject.Find("Canvas_Ui").GetComponent<Player_Ui>();
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
        if(Xp >= startXp)
        {
            Xp -= startXp;
            startXp += stepXp;
            Level += 1;
            playerUi.LevelUp();
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
