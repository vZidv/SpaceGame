using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon : MonoBehaviour
{
    [SerializeField] GameObject weaponNow;
    public float speedRotation;
    public GameObject[] inventory;
    [SerializeField] GameObject[] allWeapon;

    void Start()
    {
        weaponNow = allWeapon[0];
        inventory[0] = allWeapon[0];
        weaponNow.SetActive(true);

    }

    void FixedUpdate()
    {
        #region Rotation
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos -= transform.position;
        float rotate = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rotate - 90), speedRotation * Time.deltaTime) ;
        #endregion
        if (Input.GetKey(KeyCode.Mouse0))
            weaponNow.GetComponent<Weapon_Controller>().Shoot();
        if (Input.GetKey(KeyCode.Alpha1))
            if (inventory[0])
            {
                weaponNow.SetActive(false);
                weaponNow = inventory[0];
                weaponNow.SetActive(true);
            }
        if (Input.GetKey(KeyCode.Alpha2))
            if (inventory[1])
            {
                weaponNow.SetActive(false);
                weaponNow = inventory[1];
                weaponNow.SetActive(true);
            }
        if (Input.GetKey(KeyCode.Alpha3))
            if (inventory[2])
            {
                weaponNow.SetActive(false);
                weaponNow = inventory[2];
                weaponNow.SetActive(true);
            }
    }
}
