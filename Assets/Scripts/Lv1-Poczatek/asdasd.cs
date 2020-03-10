using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdasd : MonoBehaviour
{
    GameObject cube;
    public bool visited = false;
    void OnTriggerEnter(Collider other)
    {

        if (visited == false)
        {
            //Debug.Log("asdasdasd");
            cube.transform.position += new Vector3(0, 0, 1);
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
        
    }
}
