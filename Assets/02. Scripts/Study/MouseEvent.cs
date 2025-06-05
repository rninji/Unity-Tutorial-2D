using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    void Update()
    {
        MouseClickEvent();
    }

    void MouseClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MOuse Button Down");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("MOuse Button");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("MOuse Button Up");
        }
    }
}
