using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class firstDoorInteraction : MonoBehaviour
{
    public AudioSource firstDoorSoound;
    private Animator ani;
    private float Speed = 20;

    // ���⿡ �� ������ �ִϸ��̼� ��
    public void OpenDoor()
    {
        Debug.Log("������");
        Destroy(this.gameObject);
        firstDoorSoound.Play();
        //transform.position = new Vector3(0f, 0f, 0f);
    }
}
