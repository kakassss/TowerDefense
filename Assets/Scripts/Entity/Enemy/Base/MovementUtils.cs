using UnityEngine;

public class MovementUtils
{
    private const float ACCELERATION_TIME = 0.3f;
    private const int EnemyLayerMask = 1 << 9;
    private const int TowerLayerMask = 1 << 8;

    private float _currentSpeed;
    private int _rayCastDistance = 1;
    
    public bool CanMove = false;
    
    public bool TranslateForward(Transform transform, float movementSpeed,Rigidbody rigidbody,BaseEnemyAnimator animator, float direction = 1)
    {
        if (IsTargetValid(transform.position, -transform.right, _rayCastDistance, TowerLayerMask) == false)
        {
            rigidbody.isKinematic = false;
            rigidbody.linearVelocity = Vector3.zero;
            
            CanMove = false;
            return false;
        }

        if (IsTargetValid(transform.position, -transform.right, _rayCastDistance, EnemyLayerMask) == false)
        {
            rigidbody.isKinematic = false;
            rigidbody.linearVelocity = Vector3.zero;
            
            CanMove = false;
            return false;
        }
        
        animator.SetWalking();
        
        rigidbody.isKinematic = true;
        CanMove = true;
        
        Vector3 moveTowards = -Vector3.right * (movementSpeed * Time.deltaTime * direction);
        transform.position += moveTowards;
        return true;
       // Debug.DrawRay(transform.position, transform.forward * _rayCastDistance, Color.yellow);
    }

    public bool IsTargetValid(Vector3 origin, Vector3 direction, float distance,LayerMask mask)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(origin, direction, out hitInfo, distance, mask))
        {
            return false;
        }
        
        return true;
    }
    
    public void TranslateForwardSmooth(Transform transform, float movementSpeed, float direction = 1)
    {
        // Smooth acceleration
        _currentSpeed = Mathf.Lerp(_currentSpeed, movementSpeed, Time.deltaTime / ACCELERATION_TIME);
        
        // Calculate target position
        Vector3 targetPosition = transform.position + (-Vector3.right * (_currentSpeed * Time.deltaTime * direction));
        
        // Smooth movement
        transform.position = Vector3.Lerp(
            transform.position, 
            targetPosition, 
            Time.deltaTime * 10f
        );
    }
}