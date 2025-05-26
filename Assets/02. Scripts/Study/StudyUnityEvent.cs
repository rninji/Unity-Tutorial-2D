using System;
using UnityEngine;

public class StudyUnityEvent : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    void Start()
    {
        Debug.Log("Start");
    }
}
