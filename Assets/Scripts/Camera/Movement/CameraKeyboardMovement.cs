using UnityEngine;
using Zenject;

public class CameraKeyboardMovement : MonoBehaviour, IUpdate // Todo: Monobehavior olmakdan çıkar
{
    private readonly float _movementSpeed = 10f;
    private GameObject _movementRelativeGo;

    private MovementInputReader _movementInputReader;
    private UpdateProvider _updateProvider;

    [Inject]
    private void Construct(MovementInputReader movementInputReader, UpdateProvider updateProvider)
    {
        _movementInputReader = movementInputReader;
        _updateProvider = updateProvider;
        
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

        transform.position += relativeMovement * Time.deltaTime;
    }

    private void OnDisable()
    {
        _updateProvider.RemoveListener(this);
    }

    private void OnDestroy()
    {
        _updateProvider.RemoveListener(this);
    }
}
