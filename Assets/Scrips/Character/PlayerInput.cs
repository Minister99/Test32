using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public bool jumpInput;
    public float mouseXInput;
    public float mouseYInput;
   
    private void Update()
    {
        HandleMovementInput();
        HandleMouseInput();
    }

    private void HandleMovementInput()
    {
        horizontalInput = Input.GetAxis(GlobalStringWar.horizontal);
        verticalInput = Input.GetAxis(GlobalStringWar.vertical);
        jumpInput = Input.GetButtonDown(GlobalStringWar.jump);
    }

    private void HandleMouseInput()
    {
        mouseXInput = Input.GetAxis(GlobalStringWar.mouseX);
        mouseYInput = Input.GetAxis(GlobalStringWar.mouseY);
    }
}
