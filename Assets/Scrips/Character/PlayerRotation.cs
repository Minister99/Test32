using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform cameraTransform;
    public float rotationSpeed = 5f;

    private void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;  // Убираем влияние вертикали

        if (cameraForward.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
