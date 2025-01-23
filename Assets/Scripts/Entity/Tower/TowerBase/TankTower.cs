
using System.Collections.Generic;

public class TankTower : BaseTower
{
    protected override void SetTowerStats()
    {
        base.SetTowerStats();

        HealthStages = new Dictionary<int, int>()
        {
            { 1, 1000 },
            { 2, 2000 },
            { 3, 3000 },
            { 4, 4000 },
            { 5, 5000 },
            { 6, 6000 },
        };
        
        AttackType = _towerAttackTypeHolder.AttackTypes[(int)AttackTypeEnum.AttackNo];
        IRangeTypeType = _towerRangeTypeHolder.RangeTypes[(int)RangeTypeEnum.NoRange];
        Health = new BaseHealth(HealthStages,ElementType.Normal);
    }
}