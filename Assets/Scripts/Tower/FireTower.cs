using System;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : MonoBehaviour, ITowerAttacker
{
    public BaseTowerAttack Attack { get; private set; }
    public BaseHealth Health { get; private set; }


    [SerializeField] protected SphereCollider triggerCollider;
    [SerializeField] private BaseTowerAttackSO _towerAttackSo;
    
    private List<IEnemy> _enemies;
    private IEnemy _targetEnemy;
    
    
    private void Start()
    {
        _enemies = new List<IEnemy>();
        triggerCollider.radius = _towerAttackSo.Range;
        
        Attack = new BaseTowerAttack(_towerAttackSo);
        Health = new BaseHealth(100);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out IEnemy enemy)) return;
        
        _enemies.Add(enemy);
        Debug.Log("Enemy added");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out IEnemy enemy)) return;
        
        _enemies.Remove(enemy);
        Debug.Log("Enemy removed");
    }
    
    public void AttackAction()
    {
        if(_enemies.Count <= 0) return;
        
        _targetEnemy = Attack.FindClosestEnemy(transform, _enemies);
           
        Attack.AttackRate(_targetEnemy.Health.Damage,_targetEnemy);
        
        Debug.Log("enemyy " +  _targetEnemy.Health.GetCurrentHealth);
    }
}