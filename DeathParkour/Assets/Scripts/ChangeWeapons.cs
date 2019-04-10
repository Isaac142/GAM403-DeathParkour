using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapons : MonoBehaviour
{
    public GameObject[] weapons;
    PlayerMovement movement;
    public GameObject knife;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
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

        if (gun.gameObject.CompareTag("Knife"))
        {
            movement.normalSpeed = movement.normalSpeed;
        }
    }

    void WeaponSwap(int weaponNumber)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i != weaponNumber)
                weapons[i].SetActive(false);
            else
                weapons[i].SetActive(true);

        }
    }
}
