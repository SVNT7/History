using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToHead : MonoBehaviour
{

    public Transform camera;
    public Transform cameraPosition;
    public Transform bone;
    // Start is called before the first frame update
    void Start()
    {
        cameraPosition.transform.localPosition = bone.transform.localPosition;
        camera.parent = cameraPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
