using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchSprint : MonoBehaviour
{
    private MovementScript speed; // pobierz speed z MovementScript

    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float crouchSpeed = 2f;

    //private Transform changeCameraPosition;
    //private float standingHeight = 1.718f;
    //private float crouchHeight = 1f;

    private bool isCrouching;
    private FootstepSound footstepSound;

    private float sprintVolume = 1f;
    private float crouchVolume = 0.1f;

    [SerializeField] private float walkVolumeMin = 0.2f, walkVolumeMax = 0.6f;

    // co jaki odstep wydac dzwiek  
    [SerializeField] private float walkStepDistance = 0.55f;
    [SerializeField] private float sprintStepDistance = 0.35f;
    [SerializeField] private float crouchStepDistance = 0.5f;





    // Start is called before the first frame update
    void Start()
    {
        speed = transform.GetComponent<MovementScript>();
        //changeCameraPosition = transform.GetChild(0);
        footstepSound = GetComponentInChildren<FootstepSound>();
        footstepSound.SetVolumeOptions(walkStepDistance,walkVolumeMin, walkVolumeMax);

        /*footstepSound._volumeMin = walkVolumeMin;
        footstepSound._volumeMax = walkVolumeMax;
        footstepSound.stepDistance = walkStepDistance;*/

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
            speed.SetSpeed(sprintSpeed); // kapsulacja / enkapsulacja
            SetSoundVolume(sprintStepDistance, sprintVolume, sprintVolume);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            speed.SetSpeed(moveSpeed);
            SetSoundVolume(walkStepDistance, walkVolumeMin, walkVolumeMax);
        }
    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed.SetSpeed(crouchSpeed);
            SetSoundVolume(crouchStepDistance, crouchVolume, crouchVolume);

            isCrouching = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed.SetSpeed(moveSpeed);
            SetSoundVolume(walkStepDistance, walkVolumeMin, walkVolumeMax);

            isCrouching = false;
        }
    }

    void SetSoundVolume(float p_stepDistance, float p_volumeMin, float p_volumeMax)
    {
        footstepSound.SetVolumeOptions(p_stepDistance, p_volumeMin, p_volumeMax);
    }
}
