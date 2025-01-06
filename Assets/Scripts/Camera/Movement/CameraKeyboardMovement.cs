using System;
using UnityEngine;

public class CameraKeyboardMovement : IUpdate, IDisposable
{
    private readonly float _movementSpeed = 10f;
    private GameObject _movementRelativeGo;

    private readonly MovementInputReader _movementInputReader;
    private readonly UpdateProvider _updateProvider;
    private readonly Utils _utils;

    private CameraKeyboardMovement(MovementInputReader movementInputReader, UpdateProvider updateProvider, Utils utils)
    {
        _movementInputReader = movementInputReader;
        _updateProvider = updateProvider;
        _utils = utils;
        
        _movementRelativeGo = movementInputReader.GetMovementRelativeGo;
        
        _updateProvider.AddListener(this);
    }

    //50x 45y rotation
    public void UpdateBehavior()
    {
        if(_movementInputReader.IsEnabled() == false) return;
        Movement();
    }
    
    private void Movement()
    {
        Vector3 forward = _movementRelativeGo.transform.forward;
        Vector3 right = _movementRelativeGo.transform.right;

        forward.y = 0;
        right.y = 0;
        
        forward.Normalize();
        right.Normalize();
        
        Vector3 movementForward = forward * _movementInputReader.Movement.y;
        Vector3 movementRight = right * _movementInputReader.Movement.x;

        Vector3 relativeMovement = (movementForward + movementRight) * _movementSpeed;

        _utils.GetMainCameraTransform().position += relativeMovement * Time.deltaTime;
    }
    
    public void Dispose()
    {
        _updateProvider.RemoveListener(this);
    }
}
