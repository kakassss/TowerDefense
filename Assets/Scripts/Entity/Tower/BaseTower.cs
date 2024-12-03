using UnityEngine;
using Zenject;

public abstract class BaseTower : MonoBehaviour, ITower, ITowerAttacker
{
    public BaseTowerAttack Attack { get; private set;}
    public BaseHealth Health { get; private set;}
    
    [SerializeField] protected BaseTowerAttackSO _towerAttackSo;
    [SerializeField] private Transform _towerAimPoint;
    [SerializeField] private Transform _towerAimHead;
    
    private TowerAimTarget _towerAimTarget;
    private IEnemy _targetEnemy;
    private ProjectilePoolEvent _projectilePoolEvent;
    private ProjectilePool _projectilePool;
    
    [Inject]
    protected void Construct(ProjectilePool projectilePool, ProjectilePoolEvent projectilePoolEvent)
    {
        _projectilePool = projectilePool;
        _projectilePoolEvent = projectilePoolEvent;
        SetTowerStats();
    }

    protected virtual void SetTowerStats()
    {
        Attack = new BaseTowerAttack(_towerAttackSo,_projectilePool, _projectilePoolEvent);
        Health = new BaseHealth(100);
        _towerAimTarget = new TowerAimTarget();
    }
    
    public void AttackAction()
    {
        if (_targetEnemy == null)
        {
            _targetEnemy = Attack.DetectEnemies(transform);
        }
        
        if(_targetEnemy == null) return;
        
        if (Attack.InRange(_targetEnemy.Transform,transform) == false)
        {
            _targetEnemy = null;
            return;
        }
        
        _towerAimTarget.AimTowerAimTarget(_towerAimHead,_targetEnemy);
        
        Attack.AttackRate(_targetEnemy.Health.Damage,_targetEnemy,_towerAimPoint);
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        
        Gizmos.DrawWireSphere(transform.position, _towerAttackSo.Range);
        
        
        Gizmos.color = Color.red;
        if(_targetEnemy == null) return;
        Gizmos.DrawLine(transform.position,_targetEnemy.Transform.position);
    }
}