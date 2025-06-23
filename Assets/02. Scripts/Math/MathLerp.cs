using System;
using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Transform target;
    public float smoothValue;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position,  Time.deltaTime * smoothValue);
    }
}
