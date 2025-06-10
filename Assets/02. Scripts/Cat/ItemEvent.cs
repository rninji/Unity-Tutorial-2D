using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public enum ColliderType { Pipe, Apple, Both }
    public ColliderType colliderType;
    
    public float moveSpeed = 3f;
    public float returnPosX = 15f;
    public float randomPosY;

    public GameObject pipe;
    public GameObject apple;
    public GameObject collectEffect;
    
    void Start()
    {
        SetRandomPos(transform.position.x);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        
        if (transform.position.x <= -returnPosX)
        {
            SetRandomPos(returnPosX);
        }
    }

    void SetRandomPos(float posX)
    {
        randomPosY = Random.Range(-0.5f, 3.5f);
        transform.position = new Vector3(posX, randomPosY, 0);
        
        colliderType = (ColliderType)Random.Range(0, 3); // 명시적 형변환
        
        pipe.SetActive(false);
        apple.SetActive(false);

        switch (colliderType)
        {
            case ColliderType.Pipe:
                pipe.SetActive(true);
                break;
            case ColliderType.Apple:
                apple.SetActive(true);
                break;
            case ColliderType.Both:
                pipe.SetActive(true);
                apple.SetActive(true);
                break;
        }
        {
            
        }
    }
}
