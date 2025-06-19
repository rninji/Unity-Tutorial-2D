using UnityEngine;

public class MathLight : MonoBehaviour
{
    private Light light;
    private float theta;
    
    [SerializeField] private float speed;
    [SerializeField] private float power;

    void Start()
    {
        light = GetComponent<Light>();
    }
    void Update()
    {
        theta += Time.deltaTime * speed;
        // light.intensity = Mathf.Sin(theta) * power;
        
        light.intensity = Mathf.PerlinNoise(theta, 0) * power;
    }
}
