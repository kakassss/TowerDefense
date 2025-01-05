using UnityEngine;

public class MovementUtils
{
    private const float ACCELERATION_TIME = 0.3f;
    private float currentSpeed;

    public void TranslateForward(Transform transform, float movementSpeed, float direction = 1)
    {
        Vector3 moveTowards = -Vector3.right * (movementSpeed * Time.deltaTime * direction);
       
        transform.position += moveTowards;
    }

    public void TranslateForwardSmooth(Transform transform, float movementSpeed, float direction = 1)
    {
        // Smooth acceleration
        currentSpeed = Mathf.Lerp(currentSpeed, movementSpeed, Time.deltaTime / ACCELERATION_TIME);
        
        // Calculate target position
        Vector3 targetPosition = transform.position + (-Vector3.right * (currentSpeed * Time.deltaTime * direction));
        
        // Smooth movement
        transform.position = Vector3.Lerp(
            transform.position, 
            targetPosition, 
            Time.deltaTime * 10f
        );
    }
}