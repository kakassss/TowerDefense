using System;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class IdleInputReader : InputSystem_Actions.IInputIdleActions, IDisposable, IInputActions
{
    private readonly InputSystem _inputSystem;

    private IdleInputReader(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        
        _inputSystem.InputSystemActions.InputIdle.SetCallbacks(this);
        _inputSystem.InputSystemActions.InputIdle.Enable();
    }
    
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
    }
    
    public bool IsEnabled()
    {
        return _inputSystem.InputSystemActions.InputIdle.enabled;
    }

    public void Disable()
    {
        _inputSystem.InputSystemActions.InputIdle.Disable();
    }
    
    public void Dispose()
    {
        _inputSystem.InputSystemActions.InputBuild.Disable();
    }
}
