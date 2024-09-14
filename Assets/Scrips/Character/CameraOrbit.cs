using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // Игрок, вокруг которого вращается камера
    public Transform player; // Игрок, который будет вращаться вместе с камерой
    public float distance = 5.0f;
    public float sensitivityX = 100f;
    public float sensitivityY = 100f;
    public float minY = -20f;
    public float maxY = 80f;

    private float _currentX = 0f;
    private float _currentY = 0f;
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerInput = target.GetComponent<PlayerInput>();
        _playerMovement = player.GetComponent<PlayerMovement>(); // Получаем компонент PlayerMovement
        HideCursor();
    }

    private void Update()
    {
        if (_playerInput != null)
        {
            HandleCameraRotation();
            ClampYRotation();
            RotatePlayer();
            UpdatePlayerMovementDirection();
            HandleJump();
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

    private void RotatePlayer()
    {
        if (player != null)
        {
            player.rotation = Quaternion.Euler(0, _currentX, 0);
        }
    }

    private void UpdatePlayerMovementDirection()
    {
        if (_playerMovement != null)
        {
            // Направление движения в мировых координатах
            Vector3 forward = new Vector3(Mathf.Sin(_currentX * Mathf.Deg2Rad), 0, Mathf.Cos(_currentX * Mathf.Deg2Rad));
            Vector3 right = new Vector3(Mathf.Cos(_currentX * Mathf.Deg2Rad), 0, -Mathf.Sin(_currentX * Mathf.Deg2Rad));

            // Направление движения игрока, основанное на вводе
            Vector3 direction = forward * _playerInput.verticalInput + right * _playerInput.horizontalInput;
            direction = direction.normalized;

            _playerMovement.SetMovementDirection(direction);
        }
    }

    private void HandleJump()
    {
        if (_playerMovement != null)
        {
            // Передача информации о прыжке в PlayerMovement
            _playerMovement.SetJump(_playerInput.jumpInput);
        }
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
