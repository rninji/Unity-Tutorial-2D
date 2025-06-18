using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sRenderer;
    public SpawnManager spawner;
    
    protected float hp = 3f;
     bool isMove = true;
     bool isHit = false;
   
    [SerializeField]
    protected float moveSpeed = 3f;

    int dir = 1;

    public abstract void Init();

    void Start()
    {
        spawner = FindFirstObjectByType<SpawnManager>();
        anim = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
        Init();
    }
    void Update()
    {
        Move();
    }

    void OnMouseDown()
    { 
        StartCoroutine(Hit(1));
    }

    void Move()
    {
        if (isMove == false)
            return;
        
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

    IEnumerator Hit(float damage)
    {
        if (isHit)
            yield break;
        
        isHit = true;
        hp -= damage;
        isMove = false;
        anim.SetTrigger("Hit");
        
        if (hp <= 0)
        {
            anim.SetTrigger("Death");
            
            spawner.DropItem(gameObject.transform.position); // 코인 생성
            
            yield return new WaitForSeconds(3.0f);
            Destroy(gameObject);
            
            
            yield break;
        }

        yield return new WaitForSeconds(0.5f);
        isMove = true;
        isHit = false;
    }
}
