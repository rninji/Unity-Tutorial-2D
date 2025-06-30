using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float theta;
    public float power = 0.1f;
    public float speed = 1f;

    private Vector3 initPos;
    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        theta += Time.deltaTime * speed;
        transform.position = new Vector3(initPos.x + power * Mathf.Sin(theta), initPos.y, initPos.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.transform.SetParent(null);
    }
}
