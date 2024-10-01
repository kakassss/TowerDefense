using UnityEngine;

public class EnemyFireDefence : IEnemyDefence, IEnemy
{
    public BaseEnemyDefence Stats;
    public int FireDefence;
    
    public bool DefenceAction(int stat)
    {
        if (FireDefence <= stat) return false;
        
        Debug.Log("Observed");
        return true;
    }

    public BaseHealth Health { get; }
    public BaseEnemyDefence Defence { get; set; }
    public BaseEnemyAttack Attack { get; }
    public Transform Position { get; }

    public bool DefenceAction(int value, ElementType elementType)
    {
        throw new System.NotImplementedException();
    }
}