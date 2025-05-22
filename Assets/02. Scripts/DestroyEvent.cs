using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name} 파괴되었습니다");
    }
}
