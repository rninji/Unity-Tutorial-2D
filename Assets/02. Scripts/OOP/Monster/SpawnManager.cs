using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] monsters;
    [SerializeField] GameObject[] items;

    IEnumerator Start()
    {
        while (true)
        {
            var randomIndex = Random.Range(0, monsters.Length);
            var randomX = Random.Range(-8, 9);
            var randomY = Random.Range(-3, 6);
            var createPos = new Vector2(randomX, randomY);
            
            Instantiate(monsters[randomIndex], createPos, Quaternion.identity);
            
            yield return new WaitForSeconds(1f);
        }
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
}
