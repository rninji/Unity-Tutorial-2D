using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
   public enum InteractionType { SIGN, DOOR, NPC }
   public InteractionType type;

   [SerializeField] private CameraFollow camera;

   public GameObject popup;
   public GameObject map;
   public GameObject house;

   public Fade fade;

   public Vector3 inDoorPos;
   public Vector3 outDoorPos;

   public bool isHouse;

   [SerializeField] SoundController soundController;
   
   public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         Interaction(other.transform);
      }
   }

   public void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {      
         popup.SetActive(false);
      }
   }

   void Interaction(Transform player)
   {
      switch (type)
      {
         case InteractionType.SIGN:
            popup.SetActive(true);
            break;
         case InteractionType.DOOR:
             StartCoroutine(DoorRoutine(player));
            break;
         case InteractionType.NPC:
            popup.SetActive(true);
            break;
      }
   }

   IEnumerator DoorRoutine(Transform player)
   {
      soundController.EventSoundPlay("Door");
      
      yield return StartCoroutine(fade.FadeRoutine(2f, Color.black, true));
      
      player.transform.position = isHouse ? outDoorPos : inDoorPos;
      map.SetActive(isHouse);
      house.SetActive(!isHouse);
      
      isHouse = !isHouse;
      camera.isHouse = isHouse;
      
      
      
      yield return StartCoroutine(fade.FadeRoutine(2f, Color.black, false));
   }
}
