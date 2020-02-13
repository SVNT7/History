using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{


    public CharacterController controller;

    public Animator animacje;


    public float speed = 12f;
    public float jumpHeight = 3f;
    private float verticalVelocity;

    Vector3 moveDirection;
    Vector3 velocity;
    public Vector3 move;
    public float gravity = 20f;

    /*public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded; */

     

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        MovePlayer();
    }

    void MovePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        controller.Move(moveDirection);
    }

    void ApplyGravity()
    {
        if (controller.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            PlayerJump();
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        moveDirection.y = verticalVelocity * Time.deltaTime;
    }

    void PlayerJump()
    {
        if(controller.isGrounded && Input.GetKey(KeyCode.Space))
        {
            verticalVelocity = jumpHeight;
        }
    }
}
