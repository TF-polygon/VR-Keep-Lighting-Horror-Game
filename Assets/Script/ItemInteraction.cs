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

        TurnOffInteraction(); // Emission �ʱ�ȭ
    }

    public void TurnOnInteraction()
    {
        material.EnableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Color.white); // Emission �Ͼ������ ����
    }

    public void TurnOffInteraction()
    {
        material.SetColor("_EmissionColor", Color.black); // ���� Emission �������� ����
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
