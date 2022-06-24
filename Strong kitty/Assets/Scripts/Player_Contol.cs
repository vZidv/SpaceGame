using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Contol : MonoBehaviour
{
    public float health;
    private float healthStart;
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
        if (Input.GetKey(KeyCode.LeftShift))
            speed = SpeedBoost;
        else
            speed = startSpeed;

        hor = (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        ver = (Input.GetAxis("Vertical") * speed * Time.deltaTime);

        Vector3 pos = new Vector3(hor, ver, 0);
        transform.position += pos;
        if (health > healthStart)
            health = healthStart;
        else if (health <= 0 && !isDead)
        {
            // GameObject.Find("Player_Ui").GetComponent<Ui_Manager>().DeadScrean();
            isDead = true;
        }

    }
}
