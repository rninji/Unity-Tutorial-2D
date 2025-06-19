using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    [SerializeField] private GameObject hitBox;
    [SerializeField] private float moveSpeed = 3f;
    private float h, v;
    private bool isAttack = false;

    void Start()
    {
        animator  = GetComponent<Animator>();
    }
    
    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        h =  Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h == 0 && v == 0)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            if (h > 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
            else if (h < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);

            animator.SetBool("Run", true);
            
            var dir = new Vector3(h, v, 0).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
        
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        hitBox.SetActive(true);
        
        yield return new WaitForSeconds(0.25f);
        hitBox.SetActive(false);
        
        yield return new WaitForSeconds(0.25f);
        isAttack = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Monster>() != null)
        {
            Monster monster = other.GetComponent<Monster>();
            StartCoroutine(monster.Hit(1f));
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<IItem>() != null)
        {
            IItem item = other.gameObject.GetComponent<IItem>();
            item.Get();
        }
    }
}
