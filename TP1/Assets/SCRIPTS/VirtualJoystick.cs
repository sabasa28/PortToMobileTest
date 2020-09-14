using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] RectTransform stick;
    [SerializeField] Image background;
    float limit = 250f;
    public void OnPointerDown(PointerEventData eventData)
    {
        background.color = Color.red;
        stick.anchoredPosition = ConvertToLocal(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = ConvertToLocal(eventData);
        if (pos.magnitude > limit)
        {
            pos = pos.normalized * limit;
        }
        stick.anchoredPosition = pos;

        float x = pos.x / limit; //para despues
        float y = pos.y / limit; //para despues
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        background.color = Color.gray;
        stick.anchoredPosition = Vector2.zero;
    }

    Vector2 ConvertToLocal(PointerEventData eventData)
    {
        Vector2 newPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out newPos
            );
        return newPos;
    }

}
