using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectImageTrue : MonoBehaviour
{
    [SerializeField]
    Image objImage;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(objImage.name);
        if(objImage == null)
        {
            Debug.Log("����");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetImage()
    {
        if (objImage != null)
        {
            Debug.Log("GetImage ����" + ": " + objImage.name);
            GetComponent<InvScript>().ImageTrue(objImage);
        }
    }
}
