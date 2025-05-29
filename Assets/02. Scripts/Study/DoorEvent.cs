using System;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Open");
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Close");
    }
}
