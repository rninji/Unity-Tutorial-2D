using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    SpriteRenderer sRenderer;
    protected float hp = 3f;
   
    [SerializeField]
    protected float moveSpeed = 3f;

    int dir = 1;

    public abstract void Init();

    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        Init();
    }
    void Update()
    {
        Move();
    }

    void OnMouseDown()
    {
        Hit(1);
    }

    void Move()
    {
        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;
        if (transform.position.x > 8f)
        {
            dir = -1;
            sRenderer.flipX = true;
        }
        else if (transform.position.x < -8f)
        {
            dir = 1;
            sRenderer.flipX = false;         
        }
    }

    void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log($"몬스터 사망 : {gameObject.name}");
            Destroy(gameObject);
        }
    }
}
