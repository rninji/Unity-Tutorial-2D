using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Movement.coinCount++;
            Debug.Log($"코인 획득!! {Movement.coinCount}개");
            Destroy(gameObject);
        }
    }
}
