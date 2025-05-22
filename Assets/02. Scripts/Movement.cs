using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Vector3 dir = new Vector3(h, 0, v);
        Debug.Log($"현재 입력 : {dir}");
        transform.position += dir * moveSpeed * Time.deltaTime;

    }
}
