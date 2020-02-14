using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCameraMovement : MonoBehaviour
{
    public Transform cameraPosition;
    private bool crouched;
    [SerializeField] private Vector3 _oldCameraPosition;
    [SerializeField] private Vector3 _newCameraPositionCrouch;
    private Vector3 newCameraPositionJump;
    
    [SerializeField]private Vector3 _backToOldCameraPosition;

    public float speed = 2f;
    public float delay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

        _oldCameraPosition = cameraPosition.transform.localPosition;
        // _newCameraPositionCrouch = new Vector3(0.1f, 3f, -0.900f);
        
        // newCameraPositionJump = new Vector3(0.1f, 3f, 0.900f);
        
        // backToOldCameraPosition = new Vector3(0f, 1.718f, 0.525f);
        
        if (Input.GetKey(KeyCode.LeftControl)){
            transform.localPosition = Vector3.Lerp(_oldCameraPosition, _newCameraPositionCrouch, speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)){
            transform.localPosition = Vector3.Lerp(_backToOldCameraPosition, _newCameraPositionCrouch, speed * Time.deltaTime);
        }

    }

}
