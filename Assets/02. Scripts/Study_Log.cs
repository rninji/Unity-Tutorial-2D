using UnityEngine;

public class Study_Log : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start 함수 실행");
        Debug.LogWarning("Start 함수 실행");
        Debug.LogError("Start 함수 실행");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update 함수 실행");Debug.Log("Start 함수 실행");
    }
}