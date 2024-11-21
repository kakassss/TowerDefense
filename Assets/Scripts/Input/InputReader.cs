using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputReader : InputSystem_Actions.ITowerDefenceActions, IDisposable
{
    private InputSystem_Actions _inputSystemActions;
    private InputActions _inputActions;
    private GhostObjectReceiver _ghostObjectReceiver;

    
    public Vector2 movement { get; private set; }
    private InputReader(InputActions inputAction,GhostObjectReceiver ghostObjectReceiver)
    {
        _inputActions = inputAction;
        _ghostObjectReceiver = ghostObjectReceiver;
        
        _inputSystemActions = new InputSystem_Actions();
        _inputSystemActions.TowerDefence.SetCallbacks(this);
        _inputSystemActions.TowerDefence.Enable();
    }

    public void OnTowerSpawn(InputAction.CallbackContext context)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if(_ghostObjectReceiver.GhostObjectValid == false) return;
        
        if (context.performed)
        {
            _inputActions.SpawnInputAction();
        }
        
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //_inputActions.GhostSpawnInputAction();
        }
    }

    public void OnCameraMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Dispose()
    {
        _inputSystemActions?.Dispose();
        _inputSystemActions.TowerDefence.Disable();
    }
}
