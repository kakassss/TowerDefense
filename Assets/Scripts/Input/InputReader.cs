using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

public class InputReader : MonoBehaviour, InputSystem_Actions.ITowerDefenceActions
{
    private InputSystem_Actions _inputSystemActions;
    private InputActions _inputActions;
    private GhostObjectReceiver _ghostObjectReceiver;

    [Inject]
    private void Construct(InputActions inputAction,GhostObjectReceiver ghostObjectReceiver)
    {
        _inputActions = inputAction;
        _ghostObjectReceiver = ghostObjectReceiver;
    }
    
    private void Start()
    {
        _inputSystemActions = new InputSystem_Actions();
        _inputSystemActions.TowerDefence.SetCallbacks(this);
        _inputSystemActions.TowerDefence.Enable();
    }

    private void OnDestroy()
    {
        _inputSystemActions.TowerDefence.Disable();
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
}
