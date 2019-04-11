using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapons : MonoBehaviour
{
    public GameObject[] weapons;
    public PlayerMovement movement;
    public GameObject knife;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
        Cursor.visible = false;
        Debug.Log(weapons.Length);
        WeaponSwap(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponSwap(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponSwap(1);
        }

        //if (gun.gameObject.CompareTag("Gun"))
        //{
        //    movement.currentSpeed = movement.gunspeed;
        //}
        //if (knife.gameObject.CompareTag("Knife"))
        //{
        //    movement.currentSpeed = movement.knifeSpeed;
        //}
    }

    void WeaponSwap(int weaponNumber)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i != weaponNumber)
            {
                weapons[i].SetActive(false);
                

            }

            else
            {
                weapons[i].SetActive(true);
                movement.currentSpeed = weapons[i].GetComponent<Weapon>().weaponSpeed;
                movement.currentjumpForce = weapons[i].GetComponent<Weapon>().weaponJump;
            }

        }
    }
}
