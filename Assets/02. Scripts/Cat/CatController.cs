using System;
using System.Collections;
using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;
    public GameObject playUI;
    
    private Rigidbody2D catRb;
    Animator catAnim;
    
    public float jumpPower = 10f;
    public float limitPower = 20f;
    public bool isGround = false;

    public int jumpCount = 0;

    void Awake()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }
    void Start()
    {
    }

    void OnEnable()
    {
        transform.localPosition = new Vector3(-7.9f, -1.18f, 0f);
        GetComponent<CircleCollider2D>().enabled = true;
        soundManager.audioSource.Play();
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
            fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.black, true);
            GetComponent<CircleCollider2D>().enabled = false;
            
            StartCoroutine(EndingRoutine(false));
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
                fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.white, true);
                GetComponent<CircleCollider2D>().enabled = false;
                
                StartCoroutine(EndingRoutine(true));
            }
        }
    }

    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);
        
        videoManager.VideoPlay(isHappy); // 영상 재생 시작
        yield return new WaitForSeconds(1f);
        
        var newColor = isHappy ? Color.white : Color.black;
        fadeUI.GetComponent<FadePanel>().OnFade(3f, newColor, false); // 페이드 실행
        
        yield return new WaitForSeconds(3f);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.Stop();
        transform.parent.gameObject.SetActive(false); // PLAY 오브젝트 Off
        // soundManager.audioSource.mute = true; // 음소거
        
    }
}
