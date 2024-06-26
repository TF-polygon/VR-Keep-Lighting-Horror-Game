using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poltergeist : MonoBehaviour
{
    private float velocity = 1.0f;
    private float distance = 2.0f;

    private Vector3 TargetPos;

    private bool isMoving = false;

    void Start()
    {

    }

    public void MovingObject()
    {
        TargetPos = transform.position + transform.right * distance;
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            //transform.position = Vector3.MoveTowards(transform.position, TargetPos, velocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, TargetPos, velocity * Time.deltaTime);
            if (Vector3.Distance(transform.position, TargetPos) < 0.001f)
            {
                isMoving = false;
            }
        }
    }
}
