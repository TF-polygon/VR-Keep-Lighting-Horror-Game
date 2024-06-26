using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public Material material;
    private Color originalEmissionColor;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;
        originalEmissionColor = material.GetColor("_EmissionColor");

        TurnOffInteraction(); // Emission 초기화
    }

    public void TurnOnInteraction()
    {
        material.EnableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Color.white); // Emission 하얀색으로 설정
    }

    public void TurnOffInteraction()
    {
        material.SetColor("_EmissionColor", Color.black); // 원래 Emission 색상으로 복원
        material.DisableKeyword("_EMISSION");
    }

    public void get_item()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
