using System.Collections.Generic;

public class TowerAttackTypeHolder
{ 
    private readonly List<IAttackType> _attackTypes;
    public List<IAttackType> AttackTypes => _attackTypes;
    
    private TowerAttackTypeHolder(TowerAttackClosest towerAttackClosest, TowerAttackMostHp towerAttackMostHp
        ,TowerAttackNoAttack towerAttackNoAttack)
    {
        _attackTypes = new List<IAttackType>
        {
            towerAttackClosest,
            towerAttackMostHp,
            towerAttackNoAttack
        };
    }
}

public enum AttackTypeEnum
{
    AttackClosest = 0,
    AttackMostHp = 1,
    AttackNo = 2,
}
