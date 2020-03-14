using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _controller;

    /*[SerializeField] private bool isCrouching;
    [SerializeField] private bool isWalking;*/

    private string isWalking = "isWalking";
    private string isCrouching = "isCrouching";
    private string isRunning = "isRunning";
    private string isJumping = "isJumping";

    //[SerializeField] private float maxSpeed = 10f;

    // stringi do zmiennych

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // poruszanie sie
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool(isWalking, true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool(isWalking, false);
        }
        
        // kucanie
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _animator.SetBool(isCrouching, true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _animator.SetBool(isCrouching, false);
        }

        // sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool(isRunning, true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animator.SetBool(isRunning, false);
        }

        // skok
        if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
        {
            _animator.SetBool(isJumping, true);
        }
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            _animator.SetBool(isJumping, false);
        }

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        _animator.SetFloat("VelX", x);
        _animator.SetFloat("VelY", y);

        /*if (Input.GetKeyDown(KeyCode.LeftControl)){
            isCrouching = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)){
            isCrouching = false;
        }*/

    }
}
