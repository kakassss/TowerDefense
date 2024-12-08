using UnityEngine;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    [SerializeField] private float movementSpeed;
    
    [SerializeField] private GameObject movementRelativeGO;

    private MovementInputReader _movementInputReader;
    private BuildingInputReader _buildingInputReader;

    [Inject]
    private void Construct(MovementInputReader movementInputReader)
    {
        _movementInputReader = movementInputReader;
    }

    //50x 45y rotation
    private void Update()
    {
        if(_movementInputReader.IsEnabled() == false) return;
        Movement();
    }
    
    private void Movement()
    {
        Vector3 forward = movementRelativeGO.transform.forward;
        Vector3 right = movementRelativeGO.transform.right;

        forward.y = 0;
        right.y = 0;
        
        forward.Normalize();
        right.Normalize();
        
        Vector3 movementForward = forward * _movementInputReader.Movement.y;
        Vector3 movementRight = right * _movementInputReader.Movement.x;

        Vector3 relativeMovement = (movementForward + movementRight) * movementSpeed;

        transform.position += relativeMovement * Time.deltaTime;
    }
}
