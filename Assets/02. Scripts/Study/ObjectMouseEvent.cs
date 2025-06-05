using System;
using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }

    void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
    }

    void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }

    void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("OnMouseUpAsButton");
    }

    void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
    }

    private void OnMouseOver()
    {
        UnityEngine.Debug.Log("OnMOuseOver");
    }
}
