using System;
using System.Linq;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRb;

    public SpriteRenderer[] renderers;
    
    public float moveSpeed;
    
    private float h;

    public float jumpPower = 10f;

    private bool isGround;

    private void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();
        renderers = GetComponentsInChildren<SpriteRenderer>(true); // 자식 요소들의 요소 전부 가져와서 리스트 반환
    }

    void Update()
    { 
        // 키 입력
        h = Input.GetAxis("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            renderers[2].gameObject.SetActive(false);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            renderers[0].gameObject.SetActive(false);
            renderers[1].gameObject.SetActive(false);
            renderers[2].gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 키 입력에 따라 캐릭터가 좌우 이동하고, 이미지의 Flip 상태가 변하는 기능
    /// </summary>
    private void Move()
    {
        if (!isGround)
            return;
        if (h != 0) // 움직일 때
        {
            renderers[0].gameObject.SetActive(false);
            renderers[1].gameObject.SetActive(true);
            renderers[2].gameObject.SetActive(false);
            // Rigid Body 이동
            characterRb.linearVelocityX = h * moveSpeed * Time.deltaTime;

            if (h > 0)
            {
                renderers[0].flipX = false;
                renderers[1].flipX = false;
                renderers[2].flipX = false;
            }
            else
            {
                renderers[0].flipX = true;
                renderers[1].flipX = true;
                renderers[2].flipX = true;
            }
        }
        else // 움직이지 않을 때
        {
            renderers[0].gameObject.SetActive(true);
            renderers[1].gameObject.SetActive(false);
            renderers[2].gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 캐릭터가 +Y 방향으롤 점프하는 기능
    /// </summary>
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            characterRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            
            
        }
    }
}
