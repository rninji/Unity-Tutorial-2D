using System;
using UnityEngine;

public class HpPotion : MonoBehaviour, IItemObject
{
    public ItemManager Manager { get; set; }
    public GameObject Obj { get; set; }
    public string itemName { get; set; }
    public Sprite Icon { get; set; }

    void Start()
    {
        Manager = FindFirstObjectByType<ItemManager>();
        Obj = gameObject;
        itemName = name;
        Icon = GetComponent<SpriteRenderer>().sprite;
    }
    
    
    public void Get()
    {
        gameObject.SetActive(false); // 오브젝트 off
        Manager.GetItem(this); // 인벤토리에 추가
    }

    public void Use()
    {
        Debug.Log("HP포션 사용");
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Get();
    }
}
