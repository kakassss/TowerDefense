using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputReader : MonoBehaviour, InputSystem_Actions.ITowerDefenceActions
{
    private InputSystem_Actions _inputSystemActions;
    private InputActions _inputActions;

    [Inject]
    private void Construct(InputActions inputAction)
    {
        _inputActions = inputAction;
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
        if (context.performed)
        {
            _inputActions.SpawnInputAction();
        }
        
    }
}
