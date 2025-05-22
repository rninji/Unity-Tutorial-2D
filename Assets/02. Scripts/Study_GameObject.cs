using System;
using UnityEngine;

public class Study_GameObject : MonoBehaviour
{
    public GameObject prefab;
    public GameObject destroyObject;
    public Vector3 pos;
    public Quaternion rot;
    void Start()
    {
        CreateAmongus();
    }

    private void OnDestroy()
    {
        Debug.Log("파괴되었습니다");
    }

    public void CreateAmongus()
    {
        GameObject obj = Instantiate(prefab, pos, rot);
        obj.name = "어몽어스 캐릭터";
        Debug.Log($"자식 오브젝트의 수 : {obj.transform.childCount}");
        Debug.Log($"첫번째 자식 오브젝트의 이름 : {obj.transform.GetChild(0).name}");
        Debug.Log($"마지막 자식 오브젝트의 이름 : {obj.transform.GetChild(obj.transform.childCount - 1).name}");
    }

}
