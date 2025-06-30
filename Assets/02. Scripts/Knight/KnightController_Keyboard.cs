using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KnightController_Keyboard : MonoBehaviour
{
    Animator animator;
    Rigidbody2D knightRb;

    private Vector3 inputDir;

    private bool isGround;
    private bool isCombo;
    private bool isAttack;
    private bool isLadder;

    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float jumpPower = 1f;
    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputKeyboard();
        Jump();
        Attack();
    }
    
    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", true);
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", false);
            isGround = false;            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 공격
        if(other.CompareTag("Monster"))
            UnityEngine.Debug.Log("공격");
        
        // 사다리 감지
        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
            knightRb.gravityScale = 0;
            knightRb.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 사다리 감지
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            knightRb.gravityScale = 7;
            knightRb.linearVelocity = Vector2.zero;
        }
    }

    void InputKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        inputDir = new Vector3(h, v, 0);
        
        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);
        
        // 방향 전환
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
    
    void Move()
    {
        if (inputDir.x != 0)
            knightRb.linearVelocityX = inputDir.x * moveSpeed;

        // 사다리 타기
        if (isLadder && inputDir.y != 0)
        {
            knightRb.linearVelocityY = inputDir.y * moveSpeed;
        }
    }
    
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isAttack)
            {
                isAttack = true;
                animator.SetTrigger("Attack");
            }
            else
            {
                animator.SetBool("isCombo", true);
            }
        }
    }

    public void CheckCombo()
    {
        if (!animator.GetBool("isCombo"))
            isAttack = false;
    }

    public void EndCombo()
    {
        isAttack = false;
        animator.SetBool("isCombo", false);
    }

}
