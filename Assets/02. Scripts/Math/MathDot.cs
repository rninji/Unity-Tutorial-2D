using UnityEngine;

public class MathDot : MonoBehaviour
{
    public Vector3 vecA = new Vector3(1, 0, 0);
    public Vector3 vecB = new Vector3(0, 1, 0);

    void Start()
    {
        float result = Vector3.Dot(vecA, vecB);
        Debug.Log($"벡터의 내적 {result}");
        
        float angle = Vector3.Angle(vecA, vecB);
        Debug.Log($"벡터의 끼임각 {angle}");
    }
}
