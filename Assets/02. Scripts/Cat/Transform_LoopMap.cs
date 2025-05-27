using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float height = 1.5f;
    public Vector3 returnPos;

    void Start()
    {
        // 배경 이미지 길이가 30이기 때문에 x = 30f
        returnPos = new Vector3(30f, height, 0f);
    }
    
    void Update()
    {
        // 배경을 왼쪽으로 이동
        transform.position += Vector3.left * (moveSpeed * Time.fixedDeltaTime);

        if (transform.position.x <= -30)
        {
            transform.position = returnPos;
        }
    }
}
