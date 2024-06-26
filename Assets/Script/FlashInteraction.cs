using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashInteraction : MonoBehaviour
{
    public Transform targetParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupFlash()
    {
        transform.parent.SetParent(targetParent);
        transform.parent.localPosition = Vector3.zero;
        transform.parent.localRotation = Quaternion.identity;
        Destroy(GetComponent<BoxCollider>());
    }
}