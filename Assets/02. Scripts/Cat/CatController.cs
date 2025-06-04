using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    
    private Rigidbody2D catRb;
    Animator catAnim;
    
    public float jumpPower = 10f;
    public bool isGround = false;

    public int jumpCount = 0;
    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // 스페이스 입력
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            soundManager.OnJumpSound();
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse); // Impulse : 순간적으로 힘을 가하는 방식
            jumpCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            isGround = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            
        }
    }
}
