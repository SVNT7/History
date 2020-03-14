using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{


    [SerializeField] private CharacterController _controller;

    //public Animator animacje;


    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpHeight = 3f;

    private float verticalVelocity;
    private Vector3 moveDirection;
    //public Vector3 move;
    [SerializeField] private float _gravity = 20f;

    /*public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded; */

    // Start is called before the first frame update
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
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
        moveDirection *= _speed * Time.deltaTime;

        ApplyGravity();

        _controller.Move(moveDirection);
    }

    void ApplyGravity()
    {
        if (_controller.isGrounded)
        {
            verticalVelocity -= _gravity * Time.deltaTime;
            PlayerJump();
        }
        else
        {
            verticalVelocity -= _gravity * Time.deltaTime;
        }
        moveDirection.y = verticalVelocity * Time.deltaTime;
    }

    void PlayerJump()
    {
        if(_controller.isGrounded && Input.GetKey(KeyCode.Space))
        {
            verticalVelocity = _jumpHeight;
        }
    }
    public float GetSpeed()
    {      
        return _speed; // pobierz _speed
    }
    public void SetSpeed(float p_speed)
    {
        _speed = p_speed; // zwroc _speed do CrouchSprint
    }
}
