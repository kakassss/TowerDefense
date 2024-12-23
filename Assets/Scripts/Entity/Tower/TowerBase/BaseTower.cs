using UnityEngine;
using Zenject;

public abstract class BaseTower : MonoBehaviour, ITower, ITowerAttacker
{
    public bool CanGizmos;
    public BaseTowerAttack Attack { get; private set;}
    public BaseHealth Health { get; private set;}

    public BaseTowerAttackSO AttackStats => _towerAttackSo;
    
    public ITargetToEnemy AttackType;
    
    [SerializeField] protected BaseTowerAttackSO _towerAttackSo;
    [SerializeField] private Transform _towerAimPoint;
    [SerializeField] private Transform _towerAimHead;
    
    private IEnemy _targetEnemy;
    private QuaternionUtils _quaternionUtils;
    private TowerAttackTypeHolder _towerAttackTypeHolder;
    
    [Inject]
    protected void Construct(QuaternionUtils quaternionUtils, BaseTowerAttack attack, TowerAttackTypeHolder towerAttackTypeHolder)
    {
        _quaternionUtils = quaternionUtils;
        _towerAttackTypeHolder = towerAttackTypeHolder;
        Attack = attack;
        
        SetTowerStats();
    }

    // Using for once, kind of start
    protected virtual void SetTowerStats()
    {
        AttackType = _towerAttackTypeHolder.AttackTypes[0];// Default attack type is attack to the closest enemy
        
        Health = new BaseHealth(100);
    }
    
    public void AttackAction()
    {
        if (_targetEnemy == null)
        {
            _targetEnemy = AttackType.TargetAction(transform,_towerAttackSo);
        }
        
        if(_targetEnemy == null) return;//?
        
        if (Attack.InRange(_targetEnemy.Transform,transform,_towerAttackSo) == false)
        {
            _targetEnemy = null;
            return;
        }
        
        _quaternionUtils.
            AimToTarget(_towerAimHead,_targetEnemy.Transform,_towerAttackSo.RotateSpeed);
        Attack.
            AttackRate(_targetEnemy.Health.Damage,_targetEnemy,_towerAimPoint,_towerAttackSo);
    }
    
    void OnDrawGizmos()
    {
        if(CanGizmos == false) return;
        
        Gizmos.color = Color.magenta;
        
        Gizmos.DrawWireSphere(transform.position, _towerAttackSo.Range);
        
        
        Gizmos.color = Color.red;
        if(_targetEnemy == null) return;
        Gizmos.DrawLine(transform.position,_targetEnemy.Transform.position);
    }
}