using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class TouchField : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    // public Vector2 TouchAxis { get; private set; }
    // private int rightTouchId = -1;
    // private float maxWidth;

    // private void Start()
    // {
    //     rightTouchId = -1;
    //     maxWidth = Screen.width / 3f;
    // }
    // private void Update()
    // {
    //     SetAxis();
    // }

    // private void SetAxis()
    // {
    //     for (int i = 0; i < Input.touchCount; i++)
    //     {
    //         Touch t = Input.GetTouch(i);
    //         switch (t.phase)
    //         {
    //             case TouchPhase.Began:
    //                 if(rightTouchId == -1 && maxWidth < t.position.x)
    //                 {
    //                     rightTouchId = t.fingerId;
    //                 }   
    //                 break;
    //             case TouchPhase.Ended:
    //                 if(t.fingerId == rightTouchId)
    //                 {
    //                     TouchAxis = Vector2.zero;
    //                     rightTouchId = -1;
    //                 }   
    //                 break;
    //             case TouchPhase.Canceled:
    //                 if(t.fingerId == rightTouchId)
    //                 {
    //                     rightTouchId = -1;
    //                 }
    //                 break;
    //             case TouchPhase.Moved:
    //                 if(t.fingerId == rightTouchId)
    //                 {
    //                     TouchAxis = t.deltaPosition;
    //                 }
    //                 break;
    //             case TouchPhase.Stationary:
    //                 if (t.fingerId == rightTouchId)
    //                 {
    //                     TouchAxis = Vector2.zero;
    //                 }
    //                 break;
    //         }
    //     }
    // }
    // public Vector2 PlayerJoystickOutputVector()
    // {
    //     return TouchAxis;
    // }
    // public void OnPointerUp(PointerEventData eventData)
    // {
    //     TouchAxis = Vector2.zero;
    // }

    [SerializeField] private CameraZoom cameraZoom;
    [HideInInspector]
    public Vector2 TouchDist;
    [HideInInspector]
    public Vector2 PointerOld;
    [HideInInspector]
    protected int PointerId;
    [HideInInspector]
    public bool Pressed;

    private void Update()
    {
        if (Pressed && cameraZoom.isZooming == false)
        {
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[PointerId].position - PointerOld;
                PointerOld = Input.touches[PointerId].position;
            }
            else
            {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                PointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDist = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }

    public Vector2 PlayerJoystickOutputVector()
    {
        return TouchDist;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

}