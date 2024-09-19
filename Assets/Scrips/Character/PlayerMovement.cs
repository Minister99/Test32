using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // �������� �������� ������
    public float jumpForce = 8.0f; // ���� ������
    public float gravity = 20.0f; // ����������

    private Vector3 _movementDirection;
    private CharacterController _characterController;
    private float _verticalVelocity;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer();
    }

    public void SetMovementDirection(Vector3 direction)
    {
        _movementDirection = direction;
    }

    public void SetJump(bool jump)
    {
        if (_characterController.isGrounded)
        {
            if (jump)
            {
                _verticalVelocity = jumpForce;
            }
        }
    }

    private void MovePlayer()
    {
        if (_characterController != null)
        {
            // ���������� ����������
            _verticalVelocity -= gravity * Time.deltaTime;

            // ����������� ������
            Vector3 move = _movementDirection * speed;
            move.y = _verticalVelocity;
            _characterController.Move(move * Time.deltaTime);
        }
    }
}
