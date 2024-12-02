using UnityEngine;
using Zenject;

//_rigidbody.rotation = Quaternion.LookRotation(direction);
// if you use with on onEnable there will be rotation delay due to not using fixedUpdate
public class BaseProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    
    private ProjectilePoolEvent _projectilePoolEvent;
    //private ProjectileDataReceiver _projectileDataReceiver;
    
    private Vector3 _targetDirection;
    private float _speed = 500f;
    private float _rotateSpeed = 500f;
    
    [Inject]
    private void Construct(ProjectilePoolEvent projectilePoolEvent)
    {
        _projectilePoolEvent = projectilePoolEvent;
        
        _projectilePoolEvent.AddProjectileEnable(GetProjectileData);
    }

    private void GetProjectileData(Vector3 targetDirection)
    {
        _targetDirection = targetDirection;
    }

    private void OnEnable()
    {
        _rigidbody.isKinematic = false;
        
        Vector3 direction = (_targetDirection - transform.position).normalized;
        
        transform.rotation = Quaternion.LookRotation(direction);
        _rigidbody.AddRelativeForce(_speed * transform.forward);
    }
    
    private void OnDisable()
    {
        _projectilePoolEvent.FireDeactivated(this);
        
        _targetDirection = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.isKinematic = true;
        transform.rotation = Quaternion.identity;
    }

    private void OnDestroy()
    {
        _projectilePoolEvent.RemoveProjectileEnable(GetProjectileData);
    }
}