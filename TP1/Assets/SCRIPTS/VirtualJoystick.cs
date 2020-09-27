using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] RectTransform stick;
    [SerializeField] Image Background;

    public string player;
    public float limit;
    Color backgroundOrigColor;
    Color backgroundWhilePressedColor;

    private void Start()
    {
        backgroundOrigColor = Background.color;
        backgroundWhilePressedColor = new Color(backgroundOrigColor.r, backgroundOrigColor.g, backgroundOrigColor.b, 0.8f);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Background.color = backgroundWhilePressedColor;
        stick.anchoredPosition = ConverToLocal(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = ConverToLocal(eventData);
        if (pos.magnitude > limit)
            pos = pos.normalized * limit;
        stick.anchoredPosition = pos;

        float x = pos.x / limit;
        float y = pos.y / limit;
        
        SetHorizontal(x);
        SetVertical(y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Background.color = backgroundOrigColor;
        stick.anchoredPosition = Vector2.zero;
        SetHorizontal(0);
        SetVertical(0);
    }

    void OnDisable()
    {
        SetHorizontal(0);
        SetVertical(0);
    }

    void SetHorizontal(float val)
    {
        InputManager.Instance.SetAxis("Horizontal" + player, val);
    }
    void SetVertical(float val)
    {
        InputManager.Instance.SetAxis("Vertical" + player, val);
    }

    Vector2 ConverToLocal(PointerEventData eventData)
    {
        Vector2 newPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out newPos);
        return newPos;
    }
}
