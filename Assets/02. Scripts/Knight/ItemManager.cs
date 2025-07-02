using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject[] items;

    public void DropItem(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);
        
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        
        itemRb.AddForceX(Random.Range(-2f,2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3.0f, ForceMode2D.Impulse);
        itemRb.AddTorque(Random.Range(-1.5f,1.5f), ForceMode2D.Impulse);
    }
}
