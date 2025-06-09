using UnityEngine;

public class StudyInvoke : MonoBehaviour
{
    private float timer = 2f;
    void Start()
    {
        Debug.Log("Start");
        Invoke("Method1", timer);
        InvokeRepeating("Method1", 5f, timer);
    }

    void Method1()
    {
        Debug.Log("Invoke");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) CancelInvoke("Method1");
    }

}
