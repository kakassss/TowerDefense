using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementInputReader : InputSystem_Actions.IInputMovementKeyboardActions, IDisposable,IInputActions
{
    public Vector2 Movement { get; private set; }
    
    private readonly InputSystem _inputSystem;
    
    private MovementInputReader(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.InputSystemActions.InputMovementKeyboard.SetCallbacks(this);
        _inputSystem.InputSystemActions.InputMovementKeyboard.Enable();
    }
    
    public void OnCameraMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
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