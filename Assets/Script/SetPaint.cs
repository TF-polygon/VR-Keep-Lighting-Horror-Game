using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPaint : MonoBehaviour
{
    public string targetTag = "Paint";
    private bool check1 = false;
    public Material objectMaterial;
    public float transparency = 0.0f;
    public GameObject lightObject;
    public float flickerDuration = 3f;
    public float flickerInterval = 0.5f;

    public AudioSource lightSound; // 불빛 사운드

    private void Update()
    {
        if (check1)
        {
            if (objectMaterial != null) {
                if (transparency < 1.0f)
                {
                    Color color = objectMaterial.color;
                    color.a += Time.deltaTime * 0.01f;
                    objectMaterial.color = color;
                }
            } }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Transform destroyObj = transform.Find("Size");
            if (destroyObj != null)
            {
                Destroy(destroyObj.gameObject);
            }

            // 활성화할 자식 오브젝트 찾기
            Transform activateObj = transform.Find("InterPaint");
            Transform activateObj2 = transform.Find("ScaredGirlP2");
            if (activateObj != null)
            {
                activateObj.gameObject.SetActive(true);
            }
            if(activateObj2 != null)
            {
                activateObj2.gameObject.SetActive(true);
            }

            Destroy(other.gameObject);
            Destroy(this.gameObject.GetComponent<BoxCollider>());
            check1 = true;

            lightSound.Play();
            StartCoroutine(FlickerLights());
        }
    }

    private IEnumerator FlickerLights()
    {
        float time = 0;
        while(time < flickerDuration)
        {
            lightObject.SetActive(!lightObject.activeSelf);
            yield return new WaitForSeconds(flickerInterval);
            time += flickerInterval;
        }

        lightObject.SetActive(false);
        lightSound.Stop();
    }
}
