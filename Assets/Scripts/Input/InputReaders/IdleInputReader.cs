using System;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class IdleInputReader : InputSystem_Actions.IInputIdleActions, IDisposable, IInputActions
{
    private readonly InputSystem _inputSystem;
    
    public Action OnTowerSelected;
    
    private IdleInputReader(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        
        _inputSystem.InputSystemActions.InputIdle.SetCallbacks(this);
    }
    
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
            
        OnTowerSelected?.Invoke();
    }

    public void Enable()
    {
        _inputSystem.InputSystemActions.InputIdle.Enable();
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
