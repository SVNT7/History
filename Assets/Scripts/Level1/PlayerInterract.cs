using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterract : MonoBehaviour
{
    public Animator animator;
    public Collider item;
    public Collider itemTemp;
    public Transform bone;
    private bool isHolding = false;
    void Start()
    {
        
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E) && isHolding == false)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
            itemTemp = item;
            item.GetComponent<SphereCollider>().isTrigger = false;
            item.transform.parent = bone.transform;
            item.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            item.transform.localPosition = new Vector3(0, -0.4f, 0);
            item.transform.localRotation = Quaternion.identity;
            isHolding = true;
        }
        if (Input.GetKeyDown(KeyCode.G) && isHolding == true)
        {
            itemTemp.GetComponent<Rigidbody>().isKinematic = false;
            itemTemp.GetComponent<SphereCollider>().isTrigger = true;
            itemTemp.transform.localScale = new Vector3(1f, 1f, 1f);
            itemTemp.transform.parent = null;
            isHolding = false;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        item = other;
    }

    private void OnTriggerExit(Collider other)
    {
        item = null;
    }

    IEnumerator Hold()
    {
        yield return new WaitForSeconds(5f);
    }
}
