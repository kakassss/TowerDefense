using System.Collections.Generic;

public class TowerAttackTypeHolder
{ 
    public readonly List<ITargetToEnemy> AttackTypes;
    public readonly List<IRange> RangeTypes;
    
    private TowerAttackTypeHolder(TowerAttackClosest towerAttackClosest, TowerAttackMostHp towerAttackMostHp,
        TowerBoxRange towerBoxRange, TowerSphereRange towerSphereRange)
    {
        AttackTypes = new List<ITargetToEnemy>
        {
            towerAttackClosest,
            towerAttackMostHp
        };

        RangeTypes = new List<IRange>()
        {
            towerSphereRange,
            towerBoxRange
        };
    }
}

public enum AttackTypeEnum
{
    AttackClosest = 0,
    AttackMostHp = 1,
}

public enum RangeTypeEnum
{
    Sphere = 0,
    Box = 1,
}