using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseTowerAttack
{
    private BaseTowerAttackSO TowerAttackSo;
    
    private float _fireRateTemp;
    
    public BaseTowerAttack(BaseTowerAttackSO towerAttackSo)
    {
        TowerAttackSo = towerAttackSo;
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

        if (_fireRateTemp > TowerAttackSo.FireRate)
        {
            attackAction?.Invoke(TowerAttackSo.Damage);
            _fireRateTemp = 0;
        }
    }
}