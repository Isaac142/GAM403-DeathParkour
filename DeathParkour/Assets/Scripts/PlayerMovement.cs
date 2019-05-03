using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController controller;
    public float verticalVelocity;
    public float gravity = 14.0f;
    public float currentjumpForce = 10.0f;
    public float currentSpeed = 1.0f;
    public GameManager GM;
    //public float gunspeed = 1.0f;
    //public float knifeSpeed = 5.0f;

        //Calling on the CharacterController Component
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    //Calling the PlayerJumping function
    void Update()
    {
        PlayerJumping();
    }

    //Creating the player jumping, and player movement function.
    //If the player is on ground then he is able to jump, depending on the jumpforce and gravity.
    void PlayerJumping()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = currentjumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, 0, v) * currentSpeed);
    }

    //If the player stands on the winning platform, then the GameManager is called upon, to activate the You Win text and the restart button
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.gameObject.CompareTag("Win"))
        {
            Debug.Log("You Win");
            GM.isWon = true;
            GM.isWinButton = true;
        }

        //This DeathZone, was made so that, if the player was to touch the floor, he/she would "die" and essensially respawn back to the start.
        if (other.gameObject.CompareTag("DeathZone"))
        {
            other.gameObject.transform.position = Vector3.zero;
            //Destroy(player);
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
