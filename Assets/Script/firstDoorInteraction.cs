using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class firstDoorInteraction : MonoBehaviour
{
    public AudioSource firstDoorSoound;
    private Animator ani;
    private float Speed = 20;

    // 여기에 문 열리는 애니메이션 들어감
    public void OpenDoor()
    {
        Debug.Log("살행함");
        Destroy(this.gameObject);
        firstDoorSoound.Play();
        //transform.position = new Vector3(0f, 0f, 0f);
    }
}
