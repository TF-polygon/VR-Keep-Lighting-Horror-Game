using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondDoorInteraction1 : MonoBehaviour
{
    public Animation ani;
    public AudioSource secondDoorSound;
    // ���⿡ �� ������ �ִϸ��̼� ��
    public void OpenDoor()
    {
        Destroy(this.gameObject);
        secondDoorSound.Play();
    }
}
