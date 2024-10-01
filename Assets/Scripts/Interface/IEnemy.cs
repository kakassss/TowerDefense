using UnityEngine;

public interface IEnemy
{
    BaseHealth Health { get; }
    BaseEnemyDefence Defence { get;}
    BaseEnemyAttack Attack { get; }    
}