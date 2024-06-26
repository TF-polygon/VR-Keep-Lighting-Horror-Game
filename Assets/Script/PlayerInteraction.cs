using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float maxDistance = 3f; // Raycast �ִ� �Ÿ�
    public Transform controllerTransform; // ��Ʈ�ѷ� Transform

    private LineRenderer lineRenderer; // ���� ������ ����
    private GameObject lastInteractionObject; // ���������� ��ȣ�ۿ��� ������Ʈ

    private Vector3 rayStart; // Ray�� ����
    private Vector3 rayEnd; // Ray�� ��
    public bool KeyS;
    public bool KeyS2;
    public bool HammerS;

    public AudioSource footstepAudioSource; // �߰��� �Ҹ��� ����� AudioSource
    private Vector3 lastPosition; // ���� ��ġ

    void PlayFootstepSound()
    {
        if (!footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Play(); // �߰��� �Ҹ� ���
        }
    }

    void StopFootstepSound()
    {
        if (footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Stop(); // �߰��� �Ҹ� ���
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        KeyS = false;
        KeyS2 = false;
        HammerS = false;
        lineRenderer = GetComponent<LineRenderer>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ���ο� ���� ray ���� ����
        rayStart = controllerTransform.position + controllerTransform.forward * 0.1f; // �ణ�� ������ �߰�
        rayEnd = rayStart + controllerTransform.forward * maxDistance;

        RaycastHit hit;
        if(Physics.Raycast(rayStart, controllerTransform.forward, out hit, maxDistance))
        {
            rayEnd = hit.point; // Ray�� ������Ʈ�� ����� ���

            if (hit.collider.CompareTag("Item") || hit.collider.CompareTag("Flash") || hit.collider.CompareTag("firstDoor")||hit.collider.CompareTag("secondDoor")
                ||hit.collider.CompareTag("Battery"))
            {
                GameObject hitObject = hit.collider.gameObject;
 
                hitObject.GetComponent<ItemInteraction>().TurnOnInteraction();


                if(lastInteractionObject != null && lastInteractionObject != hitObject)
                {
                    lastInteractionObject.GetComponent<ItemInteraction>().TurnOffInteraction();
                }

                lastInteractionObject = hitObject;

                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    if (hitObject.CompareTag("Item"))
                    {
                        hitObject.GetComponent<ObjectImageTrue>().GetImage();
                        if (hitObject.name == "MainKey")
                        {
                            KeyS = true;
                        }
                        else if (hitObject.name == "SecondKey")
                        {
                            KeyS2 = true;
                        }
                        else if(hitObject.name == "Hammer")
                        {
                            HammerS = true;
                        }
                        Destroy(hitObject);
                    }
                    else if(hitObject.CompareTag("Flash"))
                    {
                        hitObject.GetComponent<FlashInteraction>().PickupFlash();
                        controllerTransform = hitObject.transform.parent;
                    }
                    else if (hitObject.CompareTag("firstDoor"))
                    {
                        if (KeyS)
                        {
                            hitObject.GetComponent<firstDoorInteraction>().OpenDoor();
                        }
                    }
                    else if (hitObject.CompareTag("secondDoor"))
                    {
                        if (KeyS2)
                        {
                            hitObject.GetComponent<secondDoorInteraction1>().OpenDoor();
                        }
                    }
                    
                }
            }
            else
            {
                if (lastInteractionObject != null)
                {
                    lastInteractionObject.GetComponent<ItemInteraction>().TurnOffInteraction();
                    lastInteractionObject = null;
                }
            }
        }
        else
        {
            if(lastInteractionObject != null)
            {
                lastInteractionObject.GetComponent<ItemInteraction>().TurnOffInteraction();
                lastInteractionObject = null;
            }
        }
        lineRenderer.SetPosition(0, rayStart);
        lineRenderer.SetPosition(1, rayEnd);

        // ���� ��ġ�� ���� ��ġ�� �ٸ��� Ȯ��
        if (transform.position != lastPosition)
        {
            PlayFootstepSound();
        }
        else
        {
            StopFootstepSound();
        }
        lastPosition = transform.position; // ���� ��ġ ������Ʈ
    }
}
