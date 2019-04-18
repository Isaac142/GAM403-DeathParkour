using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        other.gameObject.transform.position = Vector3.zero;
    //        //Destroy(player);
    //        player.GetComponent<Renderer>().material.color = Color.green;
    //    }
    //}
}
