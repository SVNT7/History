using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningScript : MonoBehaviour
{
    [SerializeField] private float _mouseSens = 100f;

    [SerializeField] private Transform _player;

    float xRotation = 0f;

    float mouseX = 0f;
    float mouseY = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // zlockuj kursor na srodku ekranu
    }
        
    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * _mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * _mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        _player.Rotate(Vector3.up * mouseX);
    }
}
