using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class BaseTower : MonoBehaviour, ITower, ITowerAttacker
{
    public BaseTowerAttack Attack { get; private set;}
    public BaseHealth Health { get; private set;}
    
    [SerializeField] protected BaseTowerAttackSO _towerAttackSo;
    
    protected List<IEnemy> _enemies;
    protected IEnemy _targetEnemy;
    
    protected ProjectilePool _projectilePool;
    
    [Inject]
    protected void Construct(ProjectilePool projectilePool)
    {
        _projectilePool = projectilePool;
        SetTowerStats();
    }

    protected virtual void SetTowerStats()
    {
        _enemies = new List<IEnemy>();
        
        Attack = new BaseTowerAttack(_towerAttackSo,_projectilePool);
        Health = new BaseHealth(100);
    }
    
    public void AttackAction()
    {
        if(_enemies.Count <= 0) return;
        
        _targetEnemy = Attack.FindClosestEnemy(transform, _enemies);
        Attack.AttackRate(_targetEnemy.Health.Damage,_targetEnemy);
    }
}