using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float maxDistance = 3f; // Raycast 최대 거리
    public Transform controllerTransform; // 컨트롤러 Transform

    private LineRenderer lineRenderer; // 라인 렌더러 참조
    private GameObject lastInteractionObject; // 마지막으로 상호작용한 오브젝트

    private Vector3 rayStart; // Ray의 시작
    private Vector3 rayEnd; // Ray의 끝
    public bool KeyS;
    public bool KeyS2;
    public bool HammerS;

    public AudioSource footstepAudioSource; // 발걸음 소리가 재생될 AudioSource
    private Vector3 lastPosition; // 이전 위치

    void PlayFootstepSound()
    {
        if (!footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Play(); // 발걸음 소리 재생
        }
    }

    void StopFootstepSound()
    {
        if (footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Stop(); // 발걸음 소리 재생
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
        // 손전등 여부에 따른 ray 방향 조정
        rayStart = controllerTransform.position + controllerTransform.forward * 0.1f; // 약간의 오프셋 추가
        rayEnd = rayStart + controllerTransform.forward * maxDistance;

        RaycastHit hit;
        if(Physics.Raycast(rayStart, controllerTransform.forward, out hit, maxDistance))
        {
            rayEnd = hit.point; // Ray가 오브젝트에 닿았을 경우

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

        // 현재 위치와 이전 위치가 다른지 확인
        if (transform.position != lastPosition)
        {
            PlayFootstepSound();
        }
        else
        {
            StopFootstepSound();
        }
        lastPosition = transform.position; // 이전 위치 업데이트
    }
}
