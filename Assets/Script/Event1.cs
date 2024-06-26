using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event1 : MonoBehaviour
{
    public TextMeshProUGUI Eventtext;
    public BoxCollider EventCollider;

    private bool EventOn = false;

    // Start is called before the first frame update

    private void Start()
    {
        Eventtext.text = "���� ���ΰ� ������� �׸��� ���ͼ� ����� ����";
        Invoke("NextText", 3f);
        Invoke("NextText2", 6f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((EventOn == false) && (other.CompareTag("Player")))
        {
            Eventtext.text = "�Ʒ� ī���� ������ ġ�� ȹ���Ͻʽÿ�";
            EventOn = true;
            EventCollider.gameObject.SetActive(false);
            Invoke("NextText3", 2f);
        }
    }

    void NextText()
    {
        Eventtext.text = "�ǰ��ϴϱ� ǫ �������";
    }
    void NextText2()
    {
        Eventtext.text = "������ ������ ���ʽÿ�.";
    }
    void NextText3()
    {
        Eventtext.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
