using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float speed;
    public float distance;
    public float lifeTime;
    public LayerMask whatIsSolid;

    [SerializeField] bool IsEnemyBull = false;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            switch (hitInfo.collider.tag)
            {
                case "Enemy":
                    Enemy_Controller enemy = hitInfo.collider.gameObject.GetComponent<Enemy_Controller>();
                    enemy.GetHit(Damage);
                    break;
                case "Player":
                    Player_Contol player = hitInfo.collider.gameObject.GetComponent<Player_Contol>();
                    player.GetDamage(Damage);
                    break;
                case "Item":
                    Item_control item = hitInfo.collider.gameObject.GetComponent<Item_control>();
                    item.health -= Damage;
                    
                    break;
            }
            Destroy(gameObject);
        }
    }
}
