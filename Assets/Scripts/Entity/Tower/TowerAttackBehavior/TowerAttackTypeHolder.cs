using System.Collections.Generic;

public class TowerAttackTypeHolder
{ 
    public readonly List<ITargetToEnemy> AttackTypes;
    
    private TowerAttackTypeHolder(TowerAttackClosest towerAttackClosest, TowerAttackMostHp towerAttackMostHp)
    {
        AttackTypes = new List<ITargetToEnemy>
        {
            towerAttackClosest,
            towerAttackMostHp
        };
    }
}