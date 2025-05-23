using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h, 0, v).normalized;
        
        transform.position += dir * moveSpeed * Time.deltaTime;
        
        transform.LookAt(transform.position + dir);

    }
}
