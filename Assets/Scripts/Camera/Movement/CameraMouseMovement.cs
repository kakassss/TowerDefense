using System;
using UnityEngine;

public class CameraMouseMovement : IUpdate, IDisposable
{
    private Vector3 _differencePosition;
    private Vector3 _velocity = Vector3.zero;
    
    private readonly float _decelerationRate = 5f;
    private readonly float _movementSpeed = 3f;
    
    private readonly MovementInputReader _movementInputReader;
    private readonly UpdateProvider _updateProvider;
    private readonly Utils _utils;
    
    private CameraMouseMovement(MovementInputReader movementInputReader, UpdateProvider updateProvider, Utils utils)
    {
        _movementInputReader = movementInputReader;
        _updateProvider = updateProvider;
        _utils = utils;

        _updateProvider.AddListener(this);
    }
    
    public void UpdateBehavior()
    {
        if(_movementInputReader.IsEnabled() == false) return;
        Movement();
    }
    
    //Mouse1,mouse2 and mouse3 can control movement
    private void Movement()
    {
        if (_movementInputReader.CanMouseInput == true)
        {
            _differencePosition = Input.mousePosition - _movementInputReader.MouseInput;
            _movementInputReader.MouseInput = Input.mousePosition;
            
            _velocity = new Vector3(-_differencePosition.x * _movementSpeed * Time.deltaTime,
                -_differencePosition.y * _movementSpeed * Time.deltaTime, 0);
            
            _utils.GetMainCameraTransform().Translate(_velocity);
        }
        if (_movementInputReader.CanMouseInput == false)
        {
            _velocity = Vector3.Lerp(_velocity, Vector3.zero, _decelerationRate * Time.deltaTime);
            if (_velocity.magnitude > 0.01f)
                _utils.GetMainCameraTransform().Translate(_velocity);
        }
    }

    public void Dispose()
    {
        _updateProvider.RemoveListener(this);
    }
}
