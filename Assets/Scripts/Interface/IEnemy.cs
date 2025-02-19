﻿using UnityEngine;

public interface IEnemy : IDeath
{
    BaseEnemyHealth Health { get; }
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
    BaseTowerHealth TowerHealth { get; }
}

public interface ITowerAttacker
{
    void AttackAction();
}
