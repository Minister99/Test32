using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public bool jumpInput;

    private void Update()
    {
        DataInput();
    }

    private void DataInput()
    {
        horizontalInput = Input.GetAxis(GlobalStringWar.horizontal);
        verticalInput = Input.GetAxis(GlobalStringWar.vertical);
        jumpInput = Input.GetButtonDown(GlobalStringWar.jump);
    }
}
