using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    [SerializeField] private float movementSpeed;
    
    [SerializeField] private GameObject movementRelativeGO;

    //50x 45y rotation
    private void Update()
    {
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


        Vector3 movementForward = forward * Input.GetAxis("Vertical");
        Vector3 movementRight = right * Input.GetAxis("Horizontal");

        Vector3 relativeMovement = (movementForward + movementRight) * movementSpeed;

        transform.position += relativeMovement * Time.deltaTime;
    }
}
