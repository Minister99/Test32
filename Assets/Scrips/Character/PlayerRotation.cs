using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    private Transform _player;

    private void Start()
    {
        _player = GetComponent<Transform>();
    }

    public void RotatePlayer(float rotationX)
    {
        if (_player != null)
        {
            _player.rotation = Quaternion.Euler(0, rotationX, 0);
        }
    }
}
