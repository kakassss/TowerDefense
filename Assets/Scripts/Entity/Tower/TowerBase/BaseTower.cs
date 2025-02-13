using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class BaseTower : MonoBehaviour, ITower, ITowerAttacker
{
    public bool CanGizmos;
    public BaseTowerAttack Attack { get; private set;}
    public BaseTowerHealth TowerHealth { get; set;}
    
    //Health Level and Health Value
    public Dictionary<int, int> HealthStages;
    
    public BaseTowerAttackSO AttackStats => _towerAttackSo;
    
    public IAttackType AttackType;
    public IRangeType IRangeTypeType;
    
    [SerializeField] protected BaseTowerAttackSO _towerAttackSo;
    [SerializeField] private Transform _towerAimPoint;
    [SerializeField] private Transform _towerAimHead;
    
    private IEnemy _targetEnemy;
    
    protected TowerAttackTypeHolder _towerAttackTypeHolder;
    protected TowerRangeTypeHolder _towerRangeTypeHolder;
    protected UpdateProvider _updateProvider;
    protected QuaternionUtils _quaternionUtils;
    
    [Inject]
    protected virtual void Construct(QuaternionUtils quaternionUtils, BaseTowerAttack attack, TowerAttackTypeHolder towerAttackTypeHolder
    , UpdateProvider updateProvider, TowerRangeTypeHolder towerRangeTypeHolder)
    {
        _quaternionUtils = quaternionUtils;
        _towerAttackTypeHolder = towerAttackTypeHolder;
        _updateProvider = updateProvider;
        _towerRangeTypeHolder = towerRangeTypeHolder;
        
        Attack = attack;
        
        SetTowerStats();
    }

    private void OnEnable()
    {
        SetInitRotation();
    }

    private void SetInitRotation()
    {
        //transform.LookAt();
    }

    // Using for once, kind of start
    protected virtual void SetTowerStats()
    {
        // Default attack type is attack to the closest enemy
        AttackType = _towerAttackTypeHolder.AttackTypes[(int)AttackTypeEnum.AttackClosest];
    }
    
    public void AttackAction()
    {
        if (_targetEnemy == null)
        {
            _targetEnemy = AttackType.AttackType(transform,_towerAttackSo);
        }
        
        // tower will always search his target, if cant find it, without this line script throws null ref
        if(_targetEnemy == null) return;
        
        if (IRangeTypeType.InRange(_targetEnemy.Transform,transform,_towerAttackSo) == false)
        {
            _targetEnemy = null;
            return;
        }
        
        _quaternionUtils.
            AimToTarget(_towerAimHead,_targetEnemy.Transform,_towerAttackSo.RotateSpeed);
        Attack.
            AttackRate(_targetEnemy,_towerAimPoint,_towerAttackSo);
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