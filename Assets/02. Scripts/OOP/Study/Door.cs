using UnityEngine;

public class Door : MonoBehaviour, IDamageable
{
    public void TakeDamage(float damage)
    {
        UnityEngine.Debug.Log($"{damage} 만큼의 피해를 입었습니다.");
    }

    public void Death()
    {
        
    }
}
