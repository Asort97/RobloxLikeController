using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

using System;
public class CameraZoom : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook tpsCamera;
    [SerializeField] private CinemachineVirtualCamera fpsCamera;
    [SerializeField] private Joystick movementJoystick;

    public bool isZooming;
    public bool isFpsView;
    public float Sensitivity;
    
    private Touch touchA;
    private Touch touchB;
    private Vector2 touchADirection;
    private Vector2 touchBDirection;
    private float dstBtwTouchesPosition;
    private float dstBtwTouchesDirections;
    private float zoom;
    private float maxWidth;

    private void Start()
    {
        maxWidth = Screen.width / 3.5f;
        tpsCamera.m_CommonLens = true;
    }

    private void Update()
    {
        if (Input.touchCount == 2 && movementJoystick.Horizontal == 0 && movementJoystick.Vertical == 0)
        {
            isZooming = true;

            touchA = Input.GetTouch(0);
            touchB = Input.GetTouch(1);

            if(maxWidth < touchA.position.x && maxWidth < touchB.position.x)
            {
                touchADirection = touchA.position - touchA.deltaPosition;
                touchBDirection = touchB.position - touchB.deltaPosition;
                dstBtwTouchesPosition = Vector2.Distance(touchA.position, touchB.position);

                dstBtwTouchesDirections = Vector2.Distance(touchADirection, touchBDirection);

                zoom = dstBtwTouchesPosition - dstBtwTouchesDirections;
                var currentZoom = tpsCamera.m_Orbits[1].m_Radius + -zoom * Sensitivity;

                ZoomingCM(currentZoom);
                
                if(currentZoom <= 0.5f)
                {
                    isFpsView = true;

                    tpsCamera.gameObject.SetActive(false);
                    fpsCamera.gameObject.SetActive(true);
                }        
                else
                {
                    isFpsView = false;
                    
                    fpsCamera.gameObject.SetActive(false);
                    tpsCamera.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            isZooming = false;
        }
    }

    void ZoomingCM(float scale)
    {
        float toZoom = Mathf.Lerp(tpsCamera.m_Orbits[1].m_Radius, scale, Time.deltaTime * 100f);
        toZoom = Mathf.Clamp(toZoom, 0.4f, 8);

        tpsCamera.m_Orbits[1].m_Radius = toZoom;
        tpsCamera.m_Orbits[0].m_Height = tpsCamera.m_Orbits[1].m_Radius;
        tpsCamera.m_Orbits[2].m_Height = -tpsCamera.m_Orbits[1].m_Radius;
    }
    
}
