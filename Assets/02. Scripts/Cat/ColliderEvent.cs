using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
   public GameObject fadeUI;
   void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         // 고양이가 부딪힌 경우
         fadeUI.SetActive(true);
      }
   }
}
