using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    Animator animator;
    public string openKey;
    public string closeKey;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger(openKey);   
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger(closeKey);   
        }
    }
}

