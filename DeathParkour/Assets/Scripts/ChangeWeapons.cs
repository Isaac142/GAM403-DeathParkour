using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapons : MonoBehaviour
{
    public GameObject[] weapons;
    public PlayerMovement movement;                            
    public GameObject knife;
    public GameObject gun;


    //Calling upon the WeaponSwap function, hiding the cursor, and calling on the PlayerMovement script
    void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
        Cursor.visible = false;
        Debug.Log(weapons.Length);
        WeaponSwap(0);
    }

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


        //First attempt at making different weapons give different movement speed and jump height 


        //if (gun.gameObject.CompareTag("Gun"))
        //{
        //    movement.currentSpeed = movement.gunspeed;                                
        //}
        //if (knife.gameObject.CompareTag("Knife"))
        //{
        //    movement.currentSpeed = movement.knifeSpeed;
        //}
    }


    //Creating a loop for the weapons, to make it more efficent 
    //The loop is grabing the first weapon turning it into a number, disabling the other weapons in turn
    //The weapon selected then calls on the weapon script, which is placed on each weapon seperately, allowing the game designer, to play with the numbers
    //In turn changing the weapons allowing for different weapons to give different attributes
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
