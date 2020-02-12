using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCameraMovement : MonoBehaviour
{
    public Transform cameraPosition;
    private bool crouched;
    private Vector3 oldCameraPosition;
    private Vector3 newCameraPositionCrouch;
    private Vector3 newCameraPositionJump;

    private Vector3 backToOldCameraPosition;

    public float speed = 2f;
    public float delay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

        oldCameraPosition = cameraPosition.transform.localPosition;
        newCameraPositionCrouch = new Vector3(0.1f, 1.1f, 0.900f);

        newCameraPositionJump = new Vector3(0.1f, 3f, 0.900f);

        backToOldCameraPosition = new Vector3(0f, 1.718f, 0.525f);

        if (Input.GetKey(KeyCode.LeftControl)){
            transform.localPosition = Vector3.Lerp(oldCameraPosition, newCameraPositionCrouch, speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)){
            transform.localPosition = Vector3.Lerp(backToOldCameraPosition, newCameraPositionCrouch, speed * Time.deltaTime);
        }

    }

}
