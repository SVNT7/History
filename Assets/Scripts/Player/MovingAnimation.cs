using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAnimation : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    public bool isCrouching;
    public bool isWalking;

    public float maxSpeed = 10f;

    // stringi do zmiennych

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
        }
        

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouching", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouching", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            animator.SetBool("isJumping", true);
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            animator.SetBool("isJumping", false);
        }








        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        if (Input.GetKeyDown(KeyCode.LeftControl)){
            isCrouching = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)){
            isCrouching = false;
        }

    }
}
