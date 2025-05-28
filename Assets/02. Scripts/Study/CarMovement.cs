using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D carRb;
    float h;
    void Update()
    {
        h = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Rigidbody의 속도를 이용한 이동
        carRb.linearVelocityX = h * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("OnCollisionStay");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("OnCollisionExit");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("OnTriggerStay");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("OnTriggerExit");
    }
}
