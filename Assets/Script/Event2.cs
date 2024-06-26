using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event2 : MonoBehaviour
{

    public AudioSource runSound;
    public GameObject ma1;
    public GameObject ma2;
    public GameObject ma3;
    public GameObject ma4;

    private bool Onin = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && (Onin == false))
        {
            ma1.transform.position = new Vector3(-17.26624f, 1.368f, 34.354f);
            ma2.transform.position = new Vector3(-19.801f, 1.368f, 31.484f);
            ma3.transform.position = new Vector3(-16.46f, 1.37f, 35.67f);
            ma4.transform.position = new Vector3(-16.4f, 1.37f, 33.97f);

            Onin = true;

            runSound.Play();
            Invoke("StopRunSound", 2f);
        }
    }
    void StopRunSound()
    {
        runSound.Stop();
    }
}
