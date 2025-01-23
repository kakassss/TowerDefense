using UnityEngine;

public class TowerAttackNoAttack : BaseTowerAttack, IAttackType
{
    public TowerAttackNoAttack(ProjectilePool projectilePool, ProjectilePoolEvent projectilePoolEvent) : base(projectilePool, projectilePoolEvent)
    {
    }

    public IEnemy AttackType(Transform transform, BaseTowerAttackSO towerAttackSo)
    {
        return null;
    }
}