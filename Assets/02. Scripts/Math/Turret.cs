using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turretHead;
    private float theta;
    public float rotSpeed = 1f;
    public float rotRange = 60f;

    private bool isTarget;
    private Transform target;
    
    void Update()
    {
        if (isTarget)
            TurretTarget();
        else
            TurretIdle();
    
    }

    void TurretIdle()
    {
        theta += Time.deltaTime * rotSpeed;

        float rotY = Mathf.Sin(theta) * rotRange;
        turretHead.localRotation = Quaternion.Euler(0, rotY, 0);
    }

    void TurretTarget()
    {
        if (target != null)
            turretHead.LookAt(target);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
            isTarget = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
            isTarget = false;
        }
    }
}
