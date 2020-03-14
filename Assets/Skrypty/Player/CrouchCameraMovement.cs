using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;
    //private bool crouched;
    [SerializeField] private Vector3 _actualCameraPosition;
    [SerializeField] private Vector3 _crouchCameraPosition;
    //[SerializeField] private Vector3 _jumpCameraPosition; // TODO: w razie zmiany kamery
    
    [SerializeField]private Vector3 _defaultCameraPosition;
    //[SerializeField] private Vector3 _defaultCrouchCameraPosition;

    [SerializeField] private float _speed = 0.1f;
    //public float delay = 1.5f;

    void Awake()
    {
        _actualCameraPosition = _cameraPosition.transform.localPosition;

    }
    // Update is called once per frame
    void Update()
    {
        // _newCameraPositionCrouch = new Vector3(0.1f, 3f, -0.900f);

        // newCameraPositionJump = new Vector3(0.1f, 3f, 0.900f);

        // backToOldCameraPosition = new Vector3(0f, 1.718f, 0.525f);

        _actualCameraPosition = _cameraPosition.transform.localPosition;


        if (Input.GetKey(KeyCode.LeftControl)){
            transform.localPosition = Vector3.Lerp(_actualCameraPosition, _crouchCameraPosition, _speed * Time.deltaTime);
        }
        else {
            transform.localPosition = Vector3.Lerp(_actualCameraPosition, _defaultCameraPosition, _speed * Time.deltaTime);
        }

    }

}
