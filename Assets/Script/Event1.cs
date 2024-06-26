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
        Eventtext.text = "오늘 값싸게 맘에드는 그림을 얻어와서 기분이 좋아";
        Invoke("NextText", 3f);
        Invoke("NextText2", 6f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((EventOn == false) && (other.CompareTag("Player")))
        {
            Eventtext.text = "아래 카펫을 옆으로 치워 획득하십시오";
            EventOn = true;
            EventCollider.gameObject.SetActive(false);
            Invoke("NextText3", 2f);
        }
    }

    void NextText()
    {
        Eventtext.text = "피곤하니까 푹 쉬어야지";
    }
    void NextText2()
    {
        Eventtext.text = "현관문 앞으로 가십시오.";
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
