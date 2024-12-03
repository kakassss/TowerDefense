﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseTowerAttack
{
    private BaseTowerAttackSO TowerAttackSo;
    
    private ProjectilePool _projectilePool;
    private ProjectilePoolEvent _projectilePoolEvent;
    
    private const int enemyLayerMask = 1 << 9;
    private float _fireRateTemp;
    
    public BaseTowerAttack(BaseTowerAttackSO towerAttackSo, ProjectilePool projectilePool, ProjectilePoolEvent projectilePoolEvent)
    {
        TowerAttackSo = towerAttackSo;
        _projectilePool = projectilePool;
        _projectilePoolEvent = projectilePoolEvent;
    }
    
    public bool InRange(Transform enemyPosition,Transform towerPosition)
    {
        float distance = Vector3.Distance(enemyPosition.position, towerPosition.position);
        return distance <= TowerAttackSo.Range;
    }
    
    public IEnemy DetectEnemies(Transform transform)
    {
        Collider[] targetEnemies = Physics.OverlapSphere(transform.position, TowerAttackSo.Range,enemyLayerMask);

        foreach (var targetEnemy in targetEnemies)
        {
            Debug.Log(targetEnemy.name);
        }
        
        var closestEnemyDistance = float.MaxValue;
        IEnemy closestEnemy = null;
        
        for (int i = 0; i < targetEnemies.Length; i++)
        {
            var distance = (transform.position - targetEnemies[i].transform.position).magnitude;
            if (distance < closestEnemyDistance)
            {
                //if (targetEnemies[i].TryGetComponent(out IEnemy enemy))
                closestEnemy = targetEnemies[i].GetComponent<IEnemy>();
                closestEnemyDistance = distance;
            }
        }
        
        return closestEnemy;
    }
    
    public IEnemy FindClosestEnemy(Transform towerPosition,List<IEnemy> enemies)
    {
        if (enemies.Count <= 1)
            return enemies[0];

        var closestEnemyDistance = float.MaxValue;
        IEnemy closestEnemy = null;
        
        for (int i = 0; i < enemies.Count; i++)
        {
            var distance = (towerPosition.position - enemies[i].Transform.position).magnitude;
            if (distance < closestEnemyDistance)
            {
                closestEnemy = enemies[i];
                closestEnemyDistance = distance;
            }
        }

        return closestEnemy ?? (enemies[0]);
    }
    
    public void AttackRate(UnityAction<float> attackAction, IEnemy enemy, Transform towerAimPoint)
    {
        _fireRateTemp += Time.deltaTime;
        
        if (_fireRateTemp > TowerAttackSo.FireRate)
        {
            _projectilePoolEvent?.FireActivate(enemy.Transform.position,towerAimPoint);
            _projectilePool.GetAvailableObject().transform.position = towerAimPoint.position;
            attackAction?.Invoke(TowerAttackSo.Damage);
            _fireRateTemp = 0;
        }
    }
    
    
}