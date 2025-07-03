using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public Button inventoryButton;
        
    
    [SerializeField] GameObject[] items;
    [SerializeField] private Transform slotGroup;
    public Slot[] slots;

    void Start()
    {
        // 자신과 자식 중 T 컴포넌트가 있는 대상을 모두 가져오는 기능
        slots = slotGroup.GetComponentsInChildren<Slot>(true);
        inventoryButton.onClick.AddListener(OnInventory);
    }

    public void OnInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
    
    public void DropItem(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);
        
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        
        itemRb.AddForceX(Random.Range(-2f,2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3.0f, ForceMode2D.Impulse);
        itemRb.AddTorque(Random.Range(-1.5f,1.5f), ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.AddItem(item);
                return;
            }
        }
    }
}
