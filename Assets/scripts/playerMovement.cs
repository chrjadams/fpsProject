using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float sprintSpeed;
    public float gravity = -50.81f;
    public float jumpVelo;
    private float prevSpeed;

    public Transform gravCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start() {
        prevSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(gravCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0){
                velocity.y = -1;
            }

        if (isGrounded && Input.GetButtonDown("Jump")) {
            velocity.y = jumpVelo;
        }
        //prevSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetButton("Fire1"))
        {
            //prevSpeed = speed;
            Debug.Log("prevSpeed = " + prevSpeed);
            speed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetButton("Fire1"))
        {
            speed = prevSpeed;
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
