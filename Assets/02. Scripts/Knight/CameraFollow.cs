using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float minx, maxx, miny, maxy;
    [SerializeField] private float hminx, hmaxx, hminy, hmaxy;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed;
    
    public bool isHouse;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        
        Vector3 dest = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, dest, smoothSpeed * Time.deltaTime);

        if (isHouse)
        {
            smoothPos.x = Mathf.Clamp(smoothPos.x, hminx, hmaxx);
            smoothPos.y = Mathf.Clamp(smoothPos.y, hminy, hmaxy);
        }
        else
        {
            smoothPos.x = Mathf.Clamp(smoothPos.x, minx, maxx);
            smoothPos.y = Mathf.Clamp(smoothPos.y, miny, maxy);
        }
        
        transform.position = smoothPos;
    }
}
