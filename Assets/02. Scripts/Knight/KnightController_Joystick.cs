using System;
using UnityEngine;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{
    Animator animator;
    Rigidbody2D knightRb;
    
    [SerializeField] Button jumpButton;
    [SerializeField] Button attackButton;

    private Vector3 inputDir;

    private bool isGround;
    private bool isCombo;
    private bool isAttack;

    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float jumpPower = 1f;
    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
        
        jumpButton.onClick.AddListener(Jump);
        attackButton.onClick.AddListener(Attack);
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

    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized;
        animator.SetFloat("JoystickX", x);
        animator.SetFloat("JoystickY", y);
        
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }

    void Jump()
    {
        if (isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
    
    void Move()
    {
        if (inputDir.x != 0)
            knightRb.linearVelocityX = inputDir.x * moveSpeed;
    }

    void Attack()
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