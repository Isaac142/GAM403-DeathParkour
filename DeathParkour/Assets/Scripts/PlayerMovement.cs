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
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJumping();
    }

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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.gameObject.CompareTag("Win"))
        {
            Debug.Log("You Win");
            GM.isWon = true;
            GM.isWinButton = true;
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            other.gameObject.transform.position = Vector3.zero;
            //Destroy(player);
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
