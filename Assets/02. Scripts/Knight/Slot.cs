using System;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private IItemObject item; // 슬롯에 들어올 아이템
    public Image itemImage;
    public Button slotButton;

    public bool isEmpty = true;

    private void Awake()
    {
        slotButton = gameObject.GetComponent<Button>();
        itemImage = transform.GetChild(0).GetComponent<Image>();
        
        slotButton.onClick.AddListener(UseItem);
    }

    private void OnEnable()
    {
        // 슬롯이 비어있을 경우 아이콘, 상호작용 비활성화
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }

    public void AddItem(IItemObject newItem)
    {
        item = newItem;
        isEmpty = false;
        itemImage.sprite = newItem.Icon;
        itemImage.SetNativeSize();
        
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive((!isEmpty));
    }
    
    public void UseItem()
    {
        if (item == null) return;
        
        item.Use();
        ClearSlot();
    }

    public void ClearSlot()
    {
        item = null;
        isEmpty = true;
        
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive((!isEmpty));
    }
}
