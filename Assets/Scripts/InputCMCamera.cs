using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InputCMCamera : MonoBehaviour
{
    [SerializeField] private TouchField _touchInput;
    [SerializeField] private float _touchSpeedSensitivityX = 3f;
    [SerializeField] private float _touchSpeedSensitivityY = 3f;
    private Vector2 _lookInput;
    private string _touchXMapTo = "Mouse X";
    private string _touchYMapTo = "Mouse Y";
    private void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
    }
    private float GetInputAxis(string axisName)
    {
        _lookInput = _touchInput.PlayerJoystickOutputVector();
        if (axisName == _touchXMapTo)
            return _lookInput.x * _touchSpeedSensitivityX * Time.fixedDeltaTime;
        if (axisName == _touchYMapTo)
            return _lookInput.y * _touchSpeedSensitivityY * Time.fixedDeltaTime;
        return Input.GetAxis(axisName);
    }
}
