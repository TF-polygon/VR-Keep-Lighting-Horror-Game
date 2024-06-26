using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondDoorInteraction1 : MonoBehaviour
{
    public Animation ani;
    public AudioSource secondDoorSound;
    // 여기에 문 열리는 애니메이션 들어감
    public void OpenDoor()
    {
        Destroy(this.gameObject);
        secondDoorSound.Play();
    }
}
