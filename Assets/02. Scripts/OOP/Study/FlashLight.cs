using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;
    public bool isLight;

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        Debug.Log("손전등을 주웠다.");
    }

    public void Use()
    {
        isLight = !isLight;
        lightObj.SetActive(isLight);
        
        Debug.Log("라이트를 켠다.");
    }

    public void Drop()
    {
        transform.SetParent(null);
        transform.position = Vector3.zero;
        Debug.Log("손전등을 버렸다.");
    }
}
