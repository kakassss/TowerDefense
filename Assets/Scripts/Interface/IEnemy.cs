﻿using UnityEngine;

public interface IEnemy : IDeath
{
    BaseHealth Health { get; }
    BaseEnemyDefence Defence { get;}
    BaseEnemyAttack Attack { get; }
    public EnemyID EnemyID { get; }
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

public interface ITowerAttacker
{
    void AttackAction();
}
