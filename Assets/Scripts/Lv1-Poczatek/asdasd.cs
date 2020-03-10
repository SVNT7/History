using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdasd : MonoBehaviour
{
    GameObject cube;
    public bool visited = false;
    public GameObject Cube; //Apply the cube
    public float XSpeed;    //"Per frame, move [XSpeed]"
    public float YSpeed;    //"Per frame, move [YSpeed]"
    public float ZSpeed;    //"Per frame, move [ZSpeed]"
    void OnTriggerEnter(Collider other)
    {

        if (visited == false)
        {
            //Debug.Log("asdasdasd");
            cube.transform.position += new Vector3(0, 0, 5);
            visited = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("CzlowiekJaskinia");
    }

    // Update is called once per frame
    void Update()
    {
        Cube.transform.position = new Vector3(XSpeed, YSpeed, ZSpeed);
    }
}
