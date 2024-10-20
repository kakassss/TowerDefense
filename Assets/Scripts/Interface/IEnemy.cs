
using UnityEngine;

public interface IEnemy
{
    BaseHealth Health { get; }
    BaseEnemyDefence Defence { get;}
    BaseEnemyAttack Attack { get; }    
    public Transform Transform { get; }
}


public interface IEnemyBase
{
    BaseEnemy BaseEnemy { get; }

}
public interface ITower
{
    BaseTowerAttack Attack { get; }
    BaseHealth Health { get; }
}

public interface ITowerAttacker : ITower
{
    void AttackAction();
}
