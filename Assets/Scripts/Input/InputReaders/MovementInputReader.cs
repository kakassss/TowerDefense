using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementInputReader : InputSystem_Actions.IInputMovementActions, IDisposable,IInputActions
{
    public Vector2 Movement { get; private set; }
    
    private readonly InputSystem _inputSystem;
    
    private MovementInputReader(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.InputSystemActions.InputMovement.SetCallbacks(this);
        _inputSystem.InputSystemActions.InputMovement.Enable();
    }
    
    public void OnCameraMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }

    public bool IsEnabled()
    {
        return _inputSystem.InputSystemActions.InputMovement.enabled;
    }

    public void Disable()
    { 
        _inputSystem.InputSystemActions.InputMovement.Disable();
    }
    
    public void Dispose()
    {
        _inputSystem.InputSystemActions.InputMovement.Disable();
    }
}