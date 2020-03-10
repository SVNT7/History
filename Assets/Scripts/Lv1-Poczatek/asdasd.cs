using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdasd : MonoBehaviour
{
    public bool visited = false;
    void OnTriggerEnter(Collider other)
    {

        if (visited == false)
        {
            Debug.Log("asdasdasd");
            visited = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
