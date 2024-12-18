using UnityEngine;

public class TowerAttackMostHp : BaseTowerAttack, ITargetToEnemy
{
    public TowerAttackMostHp(ProjectilePool projectilePool, ProjectilePoolEvent projectilePoolEvent) : base(projectilePool, projectilePoolEvent)
    {
    }
    
    public IEnemy TargetAction(Transform transform,BaseTowerAttackSO towerAttackSo)
    {
        Collider[] targetableEnemies = Physics.OverlapSphere(transform.position, towerAttackSo.Range,enemyLayerMask);

        IEnemy mostHpEnemy = null;
        float minHp = 1f;
        
        for (int i = 0; i < targetableEnemies.Length; i++)
        {
            if (mostHpEnemy.Health.GetCurrentHealth < minHp)
            {
                //if (targetEnemies[i].TryGetComponent(out IEnemy enemy))
                mostHpEnemy = targetableEnemies[i].GetComponent<IEnemy>();
                minHp = mostHpEnemy.Health.GetCurrentHealth;
            }
        }
        
        return mostHpEnemy; 
    }
}