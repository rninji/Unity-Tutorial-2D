using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RuletteController : MonoBehaviour
{
   public float rotSpeed;
   public bool isStop; // 기본값 false
    void Start()
    {
        rotSpeed = 0f;
    }

    
    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
    
        // 마우스 왼쪽 버튼ㄴ을 눌렀을 때 회전하는 기능
        if (Input.GetMouseButtonDown(0))
        {
            isStop = false;
            rotSpeed = 400f;
        }
        // 스페이스바를 눌렀을 때 멈추는 기
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }
        if (isStop)
        {
            rotSpeed *= 0.98f;
            if (rotSpeed < 10f)
            {
                rotSpeed = 0f;
                isStop = false;
            }
        }
    }
}
