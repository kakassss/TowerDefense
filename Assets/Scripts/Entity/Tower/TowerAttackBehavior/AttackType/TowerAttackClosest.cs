using System.Collections.Generic;
using UnityEngine;

public class TowerAttackClosest : BaseTowerAttack, ITargetToEnemy
{
    public TowerAttackClosest(ProjectilePool projectilePool, ProjectilePoolEvent projectilePoolEvent) : base(projectilePool, projectilePoolEvent)
    {
    }
    
    //Old function
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
    
    public IEnemy TargetAction(Transform transform,BaseTowerAttackSO towerAttackSo)
    {
        Collider[] targetableEnemies = Physics.OverlapSphere(transform.position, towerAttackSo.Range,enemyLayerMask);


        // foreach (var targetEnemy in targetableEnemies)
        // {
        //     Debug.Log(targetEnemy.name);
        // }
        
        var closestEnemyDistance = float.MaxValue;
        IEnemy closestEnemy = null;
        
        for (int i = 0; i < targetableEnemies.Length; i++)
        {
            var distance = (transform.position - targetableEnemies[i].transform.position).magnitude;
            if (distance < closestEnemyDistance)
            {
                //if (targetEnemies[i].TryGetComponent(out IEnemy enemy))
                closestEnemy = targetableEnemies[i].GetComponent<IEnemy>();
                closestEnemyDistance = distance;
            }
        }
        
        return closestEnemy;
    }
}