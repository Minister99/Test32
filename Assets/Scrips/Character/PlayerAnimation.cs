using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerInput _playerInput;

    private Animator _animator;
    private string _playerJump = "playerJump";
    private string _playerRun = "playerRun";
    private string _playerIdle = "playerIdle";

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimanionOn();
        AnimationOff();
    }

    private void AnimanionOn()
    {
        if(_playerInput.jumpInput == true)
        {
            _animator.SetBool(_playerJump, true);
        }

        if(_playerInput.verticalInput > 0.1)
        {
            _animator.SetBool(_playerRun, true);
        }

        if (_playerInput.verticalInput < -0.1)
        {
            _animator.SetBool(_playerRun, true);
        }

        if (_playerInput.horizontalInput > 0.1)
        {
            _animator.SetBool(_playerRun, true);
        }

        if (_playerInput.horizontalInput < - 0.1)
        {
            _animator.SetBool(_playerRun, true);
        }
    }

    private void AnimationOff()
    {
        if (_playerInput.verticalInput == 0)
        {
            _animator.SetBool(_playerRun, false);
        }

        if (_playerInput.jumpInput == false)
        {
            _animator.SetBool(_playerJump, false);
        }
    }
}
