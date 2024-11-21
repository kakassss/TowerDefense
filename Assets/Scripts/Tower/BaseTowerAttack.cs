using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseTowerAttack
{
    private BaseTowerAttackSO TowerAttackSo;
    private ProjectilePool _projectilePool;
    
    private float _fireRateTemp;
    
    public BaseTowerAttack(BaseTowerAttackSO towerAttackSo, ProjectilePool projectilePool)
    {
        TowerAttackSo = towerAttackSo;
        _projectilePool = projectilePool;
    }
    
    public bool InRange(Transform enemyPosition)
    {
        return enemyPosition.position.magnitude <= TowerAttackSo.Range;
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
    
    public void AttackRate(UnityAction<float> attackAction, IEnemy enemy)
    {
        _fireRateTemp += Time.deltaTime;
        Debug.Log("00");
        if (_fireRateTemp > TowerAttackSo.FireRate)
        {
            Debug.Log("11");
            var pooledObj = _projectilePool._pool.GetAvailableObjects();
            attackAction?.Invoke(TowerAttackSo.Damage);
            _fireRateTemp = 0;
        }
    }
}