using System;
using UnityEngine;
using Zenject;

//_rigidbody.rotation = Quaternion.LookRotation(direction);
// if you use with on onEnable there will be rotation delay due to not using fixedUpdate
public class BaseProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BaseProjectileDataSO _baseProjectileData;
    
    private ProjectilePoolEvent _projectilePoolEvent;
   
    private Vector3 _direction;
    private Vector3 _enemyPosition;
    private Transform _spawnPosition;
    
    [Inject]
    private void Construct(ProjectilePoolEvent projectilePoolEvent)
    {
        _projectilePoolEvent = projectilePoolEvent;
        
        _projectilePoolEvent.AddProjectileEnable(GetProjectileData);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
    }

    private void GetProjectileData(Vector3 targetDirection,Transform spawnPosition)
    {
        _enemyPosition = targetDirection;
        _spawnPosition = spawnPosition;
    }

    private void OnEnable()
    {
        // after created by pool system, onEnable event will trigger with first frame,
        // to avoid that 
        if(_enemyPosition == Vector3.zero) return;
        
        transform.position = _spawnPosition.position;
        _rigidbody.isKinematic = false;
        
        _direction = (_enemyPosition - transform.position).normalized;
        
        transform.rotation = Quaternion.LookRotation(_direction);
        
    }

    // Not using rigidbody to avoid Physics.Simulate() operation
    //_rigidbody.AddForce(_baseProjectileData.Speed * transform.forward);
    private void Update()
    {
        transform.position += _baseProjectileData.Speed * Time.deltaTime * transform.forward;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        Gizmos.DrawLine(_spawnPosition.position,_enemyPosition);
    }
    private void OnDisable()
    {
        _projectilePoolEvent.FireDeactivated(this);
        
        _enemyPosition = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.isKinematic = true;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    private void OnDestroy()
    {
        _projectilePoolEvent.RemoveProjectileEnable(GetProjectileData);
    }
}