using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] GameObject backgroundUI;
    [SerializeField] GameObject handlerUI;
    
    [SerializeField] KnightController_Joystick knightController;

    Vector2 startPos, currPos;
    void Start()
    {
        backgroundUI.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundUI.SetActive(true);
        backgroundUI.transform.position = eventData.position;
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currPos = eventData.position;
        Vector2 dragDir =  currPos - startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 100f);
        
        handlerUI.transform.position = startPos + dragDir.normalized * maxDist;
        
        knightController.InputJoystick(dragDir.x, dragDir.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handlerUI.transform.position = Vector2.zero;
        backgroundUI.SetActive(false);
        knightController.InputJoystick(0, 0);
    }
}
