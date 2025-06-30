using System;
using UnityEngine;

public class PushPlatform : MonoBehaviour
{
   private Animator animator;
   private Rigidbody2D targetRb;

   [SerializeField] private float pushPower = 50f;

   void Start()
   {
      animator = gameObject.GetComponent<Animator>();
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         targetRb = other.gameObject.GetComponent<Rigidbody2D>();
         Invoke("PushCharacter", 0.1f);
      }
   }

   void PushCharacter()
   {
      targetRb.AddForceY(pushPower, ForceMode2D.Impulse);
      animator.SetTrigger("Push");
   }
}
