using System;
using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;
    public GameObject playUI;

    public GameObject happyVideo;
    public GameObject sadVideo;
    
    private Rigidbody2D catRb;
    Animator catAnim;
    
    public float jumpPower = 10f;
    public float limitPower = 20f;
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
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 4)
        {
            soundManager.OnJumpSound();
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse); // Impulse : 순간적으로 힘을 가하는 방식
            jumpCount++;

            if (catRb.linearVelocityY > limitPower)
                catRb.linearVelocityY = limitPower;
        }

        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 2f;
        transform.eulerAngles = catRotation;


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            isGround = true;
            jumpCount = 0;
        }
        
        // 파이프 충돌 시 실패 
        if (other.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();
            
            gameOverUI.SetActive(true);
            fadeUI.SetActive(true);
            fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.black);
            GetComponent<CircleCollider2D>().enabled = false;
            
            Invoke("SadVideo", 5f);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            var collectEffect = other.GetComponentInParent<ItemEvent>();
            collectEffect.collectEffect.SetActive(true);
            other.gameObject.SetActive(false);
            GameManager.score++;
            
            // 사과 10개 획득 시 해피 비디오 실행
            if (GameManager.score >= 10)
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.white);
                GetComponent<CircleCollider2D>().enabled = false;
                
                Invoke("HappyVideo", 5f);
                
            }
        }
    }

    void HappyVideo()
    {
        happyVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        playUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }

    void SadVideo()
    {
        sadVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        playUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }
}
