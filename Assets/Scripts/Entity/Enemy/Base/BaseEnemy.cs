using UnityEngine;
using Zenject;

//Enemy IDs
//0 Troll
//1 Goblin
public struct EnemyID
{
    public int ID;
    public EnemyID(int id) => ID = id;
}

public abstract class BaseEnemy : MonoBehaviour,IEnemy
{
    public BaseHealth Health { get; private set;}
    public BaseEnemyDefence Defence { get; private set; }
    public BaseEnemyAttack Attack { get; private set;}
    
    public BaseEnemyMovement Movement { get; private set; }
    public EnemyID EnemyID { get; protected set; }
    public Transform Transform => transform;
    
    [SerializeField] protected EnemyDefenceSO _enemyDefenceSo;
    [SerializeField] protected EnemyAttackSO _enemyAttackSo;

    private EnemyPoolEvent _enemyPoolEvent;
    
    [Inject]
    protected virtual void Construct(EnemyPoolEvent enemyPoolEvent)
    {
        _enemyPoolEvent = enemyPoolEvent;
        SetEnemyStats();
    }

    protected virtual void SetEnemyStats()
    {
        Defence = new BaseEnemyDefence
        {
            DefenceSo = _enemyDefenceSo
        };
        Attack = new BaseEnemyAttack(_enemyAttackSo);
        Health = new BaseHealth(Defence.DefenceSo.Health);
        Movement = new BaseEnemyMovement();
    }
    
    private void OnDisable()
    {
        _enemyPoolEvent.FireDeactivated(this,EnemyID);
    }
}

