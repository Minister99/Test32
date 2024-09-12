using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private float _xRotation = 25f;
    public Transform playerBody;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
