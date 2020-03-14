using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningScriptIntro : MonoBehaviour
{
    [SerializeField] private float mouseSens = 100f;
    //[SerializeField] private Transform player;

    float xRotation = 0f;
    float yRotation = 0f;

    float mouseX = 0f;
    float mouseY = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -55f, 55f);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -38f, 70f);


        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
