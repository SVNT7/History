using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{

    private AudioSource footstepSound;

    [SerializeField]
    private AudioClip[] footstepClip;   

    private CharacterController controller;
    public float volumeMin, volumeMax;

    private float accumulatedDistance;

    [HideInInspector]
    public float stepDistance;



    // Start is called before the first frame update
    void Start()
    {

        footstepSound = GetComponent<AudioSource>();
        controller = GetComponentInParent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayFootstepSound();   
    }

    void PlayFootstepSound()
    {
        if (!controller.isGrounded)
        {
            return;
        }
        if(controller.velocity.sqrMagnitude > 0)
        {
            accumulatedDistance += Time.deltaTime;

            if(accumulatedDistance > stepDistance)
            {
                footstepSound.volume = Random.Range(volumeMin, volumeMax);
                footstepSound.clip = footstepClip[Random.Range(0, footstepClip.Length)];
                footstepSound.Play();

                accumulatedDistance = 0f;
            }
        }
        else
        {
            accumulatedDistance = 0f;
        }
    }
}
