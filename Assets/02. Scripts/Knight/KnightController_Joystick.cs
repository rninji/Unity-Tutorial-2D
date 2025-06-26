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
    }
    
    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
       
    }

    private void OnCollisionExit2D(Collision2D other)
    {
       
    }

    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized;
        animator.SetFloat("JoystickX", x);
        animator.SetFloat("JoystickY", y);
    }
    
    void Move()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
            
        knightRb.linearVelocity = inputDir * moveSpeed;
    }
}