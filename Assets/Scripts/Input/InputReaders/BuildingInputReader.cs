using System;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BuildingInputReader : InputSystem_Actions.IInputBuildActions, IDisposable,IInputActions
{
    private readonly InputSystem _inputSystem;
    private BuildingInputEvents _buildingInputEvents;
    private GhostObjectReceiver _ghostObjectReceiver;
    
    private BuildingInputReader(InputSystem inputSystem,BuildingInputEvents buildingInputEvent,GhostObjectReceiver ghostObjectReceiver)
    {
        _buildingInputEvents = buildingInputEvent;
        _ghostObjectReceiver = ghostObjectReceiver;
        _inputSystem = inputSystem;
        
        _inputSystem.InputSystemActions.InputBuild.SetCallbacks(this);
    }

    public void OnBuilding(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if(_ghostObjectReceiver.GhostObjectValid == false) return;
            
        _buildingInputEvents.SpawnInputAction();
    }

    public void Enable()
    {
        _inputSystem.InputSystemActions.InputBuild.Enable();
    }

    public bool IsEnabled()
    {
        return _inputSystem.InputSystemActions.InputBuild.enabled;
    }

    public void Disable()
    {
        _inputSystem.InputSystemActions.InputBuild.Disable();
    }
    
    public void Dispose()
    {
        _inputSystem.InputSystemActions.InputBuild.Disable();
    }
}
