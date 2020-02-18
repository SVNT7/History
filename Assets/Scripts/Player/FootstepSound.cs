using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{

    private AudioSource footstepSound;
    [SerializeField] private AudioClip[] _footstepClip;   

    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _volumeMin, _volumeMax;

    private float accumulatedDistance;
    [SerializeField] private float _stepDistance;
    
    // serialize i zmiana na private


    // Start is called before the first frame update
    void Awake()
    {
        footstepSound = GetComponent<AudioSource>();
        _controller = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayFootstepSound();   
    }

    void PlayFootstepSound()
    {
        // jesli w powietrzu, nie wydawaj dzwieku
        if (!_controller.isGrounded)
        {
            return;
        }

        // jesli sie porusza, wydaj dzwiek
        if(_controller.velocity.sqrMagnitude > 0)
        {
            accumulatedDistance += Time.deltaTime;

            if(accumulatedDistance > _stepDistance)
            {
                footstepSound.volume = Random.Range(_volumeMin, _volumeMax);
                footstepSound.clip = _footstepClip[Random.Range(0, _footstepClip.Length)];
                footstepSound.Play();

                accumulatedDistance = 0f;
            }
        }
        else // jesli sie nie porusza, przestan wydawac dzwiek i zresetuj distance
        {
            accumulatedDistance = 0f;
        }
    }

    public float ReturnVolumeMin()
    {
        return _volumeMin;
    }

    public float ReturnVolumeMax()
    {
        return _volumeMax;
    }




    public void SetVolumeOptions(float p_stepDistance, float p_volumeMin, float p_volumeMax)
    {
        _stepDistance = p_stepDistance;
        _volumeMin = p_volumeMin;
        _volumeMax = p_volumeMax;
    }
}
