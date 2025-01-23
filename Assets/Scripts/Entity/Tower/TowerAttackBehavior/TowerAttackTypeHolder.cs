using System.Collections.Generic;

public class TowerAttackTypeHolder
{ 
    private readonly List<IAttackType> _attackTypes;
    private readonly List<IAttackType> _attackTypesUI;
    public List<IAttackType> AttackTypes => _attackTypes;
    public List<IAttackType> AttackTypesUI => _attackTypesUI;
    private TowerAttackTypeHolder(TowerAttackClosest towerAttackClosest, TowerAttackMostHp towerAttackMostHp
        ,TowerAttackNoAttack towerAttackNoAttack)
    {
        _attackTypes = new List<IAttackType>
        {
            towerAttackClosest,
            towerAttackMostHp,
            towerAttackNoAttack
        };
        
        _attackTypesUI = new List<IAttackType>
        {
            towerAttackClosest,
            towerAttackMostHp,
        };
    }
}

public enum AttackTypeEnum
{
    AttackClosest = 0,
    AttackMostHp = 1,
    AttackNo = 2,
}
