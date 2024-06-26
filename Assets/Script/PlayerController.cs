using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 200f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Update()
    {
        // WASD 이동
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(x, 0, z);

        // 마우스 회전
        yaw += turnSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= turnSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}