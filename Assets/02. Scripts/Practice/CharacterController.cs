using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public IDropItem currentItem;
    
    [SerializeField]
    float moveSpeed;

    [SerializeField] private Transform grabPos;

    void Update()
    {
        // 이동
        Move();
        
        // 아이템
        Interaction();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h, 0, v).normalized;
        
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void Interaction()
    {
        if (currentItem == null)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            currentItem.Use();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop();
            currentItem =  null;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (currentItem != null)
            return;
        if (other.GetComponent<IDropItem>() != null)
        {
            currentItem = other.GetComponent<IDropItem>();
            
            currentItem.Grab(grabPos); // 아이템 획득
        }
    }
}
