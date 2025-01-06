using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementInputReader : InputSystem_Actions.IInputMovementKeyboardActions, IDisposable,IInputActions
{
    public Vector2 Movement { get; private set; }
    public bool CanMouseInput { get; private set; }
    public Vector3 MouseInput { get; set; }

    private readonly InputSystem _inputSystem;
    
    public GameObject GetMovementRelativeGo { get; }

    private MovementInputReader(InputSystem inputSystem, GameObject movementRelativeGo)
    {
        _inputSystem = inputSystem;
        GetMovementRelativeGo = movementRelativeGo;
        
        _inputSystem.InputSystemActions.InputMovementKeyboard.SetCallbacks(this);
        _inputSystem.InputSystemActions.InputMovementKeyboard.Enable();
    }
    
    public void OnCameraMovementKeyboard(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }

    public void OnCameraMovementMouse(InputAction.CallbackContext context)
    {
        //Movement = context.ReadValue<Vector2>();
        if (context.started)
        {
            MouseInput = Input.mousePosition;
        }
        if (context.performed)
        {
            CanMouseInput = true;
        }
        if (context.canceled)
        {
            CanMouseInput = false;
            MouseInput = Vector3.zero;
        }
    }

    public void Enable()
    {
        _inputSystem.InputSystemActions.InputMovementKeyboard.Enable();
    }
    
    public bool IsEnabled()
    {
        return _inputSystem.InputSystemActions.InputMovementKeyboard.enabled;
    }

    public void Disable()
    { 
        _inputSystem.InputSystemActions.InputMovementKeyboard.Disable();
    }
    
    public void Dispose()
    {
        _inputSystem.InputSystemActions.InputMovementKeyboard.Disable();
    }
}