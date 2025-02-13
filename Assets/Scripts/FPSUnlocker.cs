using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPSUnlocker : MonoBehaviour
{
    [SerializeField] private Text fpsCounter; 
    private float fps;
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 90;
    }
    private void Update()
    {
        fps = (int)1.0f / Time.deltaTime;
        fpsCounter.text = fps.ToString();
    }
}
