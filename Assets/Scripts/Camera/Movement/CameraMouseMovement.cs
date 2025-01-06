using UnityEngine;
using Zenject;

public class CameraMouseMovement : MonoBehaviour
{
    private Vector3 _differencePosition;
    private Vector3 _velocity = Vector3.zero;
    
    private readonly float _decelerationRate = 5f;
    private readonly float _movementSpeed = 3f;
    
    private MovementInputReader _movementInputReader;
    
    [Inject]
    private void Construct(MovementInputReader movementInputReader)
    {
        _movementInputReader = movementInputReader;

    }
    
    private void Update()
    {
        AA();
    }

    private void AA()
    {
        if (_movementInputReader.CanMouseInput == true)
        {
            _differencePosition = Input.mousePosition - _movementInputReader.MouseInput;
            _movementInputReader.MouseInput = Input.mousePosition;
            
            _velocity = new Vector3(-_differencePosition.x * _movementSpeed * Time.deltaTime,
                -_differencePosition.y * _movementSpeed * Time.deltaTime, 0);
            
            transform.Translate(_velocity);
        }
        if (_movementInputReader.CanMouseInput == false)
        {
            _velocity = Vector3.Lerp(_velocity, Vector3.zero, _decelerationRate * Time.deltaTime);
            if (_velocity.magnitude > 0.01f)
                transform.Translate(_velocity);
        }
    }

}
