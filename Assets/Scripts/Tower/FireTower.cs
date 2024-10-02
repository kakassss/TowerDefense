using System;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower, ITowerAttack
{
    [SerializeField] private BaseTowerAttackSO _towerAttackSo;
    
    private List<IEnemy> _enemies;
    private IEnemy _targetEnemy;
    private void Start()
    {
        _enemies = new List<IEnemy>();
        triggerCollider.radius = _towerAttackSo.Range;
        Attack = new BaseTowerAttack(_towerAttackSo);
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

    private void Update()
    {
        AttackAction();
    }

    public void AttackAction()
    {
        if(_enemies.Count <= 0) return;
        
        _targetEnemy = Attack.FindClosestEnemy(transform, _enemies);
           
        Attack.AttackRate(_targetEnemy.Health.Damage,_targetEnemy);
        
        Debug.Log("enemyy " +  _targetEnemy.Health.GetCurrentHealth);
    }
}