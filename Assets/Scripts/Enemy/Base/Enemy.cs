using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    public BaseHealth Health { get; protected set;}
    public BaseEnemyDefence Defence { get; protected set; }
    public BaseEnemyAttack Attack { get; protected set;}
    public Transform Transform { get; }
}
