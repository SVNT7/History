using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchSprint : MonoBehaviour
{
    private MovementScript speed; // pobierz speed z MovementScript

    public float sprintSpeed = 10f;
    public float moveSpeed = 5f;

    public float crouchSpeed = 2f;
    private Transform changeCameraPosition;
    private float standingHeight = 1.718f;
    private float crouchHeight = 1f;

    private bool isCrouching;

    private FootstepSound footstepSound;
    private float sprintVolume = 1f;
    private float crouchVolume = 0.1f;
    private float walkVolumeMin = 0.2f, walkVolumeMax = 0.6f;

    private float walkStepDistance = 0.55f;
    private float sprintStepDistance = 0.35f;
    private float crouchStepDistance = 0.5f;





    // Start is called before the first frame update
    void Start()
    {
        speed = transform.GetComponent<MovementScript>();
        changeCameraPosition = transform.GetChild(0);

        footstepSound = GetComponentInChildren<FootstepSound>();

        footstepSound.volumeMin = walkVolumeMin;
        footstepSound.volumeMax = walkVolumeMax;
        footstepSound.stepDistance = walkStepDistance;

    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            speed.speed = sprintSpeed;
            footstepSound.stepDistance = sprintStepDistance;
            footstepSound.volumeMin = sprintVolume;
            footstepSound.volumeMax = sprintVolume;
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            speed.speed = moveSpeed;

            footstepSound.stepDistance = walkStepDistance;
            footstepSound.volumeMin = walkVolumeMin;
            footstepSound.volumeMax = walkVolumeMax;
        }
    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed.speed = crouchSpeed;

            footstepSound.stepDistance = crouchStepDistance;
            footstepSound.volumeMin = crouchVolume;
            footstepSound.volumeMax = crouchVolume;

            isCrouching = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed.speed = moveSpeed;

            footstepSound.stepDistance = walkStepDistance;
            footstepSound.volumeMin = walkVolumeMin;
            footstepSound.volumeMax = walkVolumeMax;

            isCrouching = false;
        }
    }
}
