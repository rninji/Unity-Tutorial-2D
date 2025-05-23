using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotSqeed = 30f; // 자전 속도
    public float revSpeed = 100f; // 공전 속도
    public Transform targetPlanet;
    public bool isRevolution = false;

    void Update()
    {
        // 자전 기능
        transform.Rotate(transform.up, rotSqeed * Time.deltaTime);
        if (isRevolution)
        {
            // 공전 기능
            transform.RotateAround(targetPlanet.position, Vector3.up, revSpeed * Time.deltaTime);
        }
        
    }
}
