using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float sensitivityX = 100f;
    public float sensitivityY = 100f;
    public float minY = -20f;
    public float maxY = 80f;

    private float _currentX = 0f;
    private float _currentY = 0f;
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = target.GetComponent<PlayerInput>();
        HideCursor();
    }

    private void Update()
    {
        if (_playerInput != null)
        {
            HandleCameraRotation();
            ClampYRotation();
        }
    }

    private void LateUpdate()
    {
        UpdateCameraPosition();
    }

    private void HandleCameraRotation()
    {
        _currentX += _playerInput.mouseXInput * sensitivityX * Time.deltaTime;
        _currentY -= _playerInput.mouseYInput * sensitivityY * Time.deltaTime;
    }

    private void ClampYRotation()
    {
        _currentY = Mathf.Clamp(_currentY, minY, maxY);
    }

    private void UpdateCameraPosition()
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target);
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
