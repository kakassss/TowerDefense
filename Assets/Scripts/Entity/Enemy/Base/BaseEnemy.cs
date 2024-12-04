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
    public EnemyID EnemyID { get; protected set; }
    public Transform Transform => transform;
    
    [SerializeField] protected EnemyDefenceSO _enemyDefenceSo;
    [SerializeField] protected EnemyAttackSO _enemyAttackSo;
    [SerializeField] protected BaseEnemyDataSO _baseEnemyDataSo;
    
    private EnemyPoolEvent _enemyPoolEvent;
    protected MovementUtils _movementUtils;
    
    [Inject]
    protected virtual void Construct(EnemyPoolEvent enemyPoolEvent, MovementUtils movementUtils)
    {
        _enemyPoolEvent = enemyPoolEvent;
        _movementUtils = movementUtils;
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
    }
    
    private void OnDisable()
    {
        _enemyPoolEvent.FireDeactivated(this,EnemyID);
    }
}

