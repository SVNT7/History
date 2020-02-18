using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterract : MonoBehaviour
{
    //public Animator animator;
    [SerializeField] private Collider _item;
    [SerializeField] private Collider _itemTemp;
    [SerializeField] private Transform _bone;
    private bool isHolding = false;

    // vectory w zmienne

    void Update()
    {
         
        
        if (Input.GetKey(KeyCode.E) && isHolding == false)
        {
            _item.GetComponent<Rigidbody>().isKinematic = true;
            _itemTemp = _item;
            _item.GetComponent<SphereCollider>().isTrigger = false;
            _item.transform.parent = _bone.transform;
            _item.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            _item.transform.localPosition = new Vector3(0, -0.4f, 0);
            _item.transform.localRotation = Quaternion.identity;
            StartCoroutine(PickupDelay(true));
            //isHolding = true;
        }
        else if (Input.GetKey(KeyCode.E) && isHolding == true)
        {
            _itemTemp.GetComponent<Rigidbody>().isKinematic = false;
            _itemTemp.GetComponent<SphereCollider>().isTrigger = true;
            _itemTemp.transform.localScale = new Vector3(1f, 1f, 1f);
            _itemTemp.transform.parent = null;
            StartCoroutine(PickupDelay(false));
            //isHolding = false;

        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        _item = other;
    }

    private void OnTriggerExit(Collider other)
    {
        _item = null;
    }

    IEnumerator PickupDelay(bool p_isHolding)
    {
        yield return new WaitForSeconds(0.5f);
        isHolding = p_isHolding; 
    }

}
