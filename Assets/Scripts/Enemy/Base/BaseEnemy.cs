using UnityEngine;
using Zenject;

public abstract class BaseEnemy : MonoBehaviour,IEnemy
{
    public BaseHealth Health { get; private set;}
    public BaseEnemyDefence Defence { get; private set; }
    public BaseEnemyAttack Attack { get; private set;}
    public Transform Transform => transform;
    
    [SerializeField] protected EnemyDefenceSO _enemyDefenceSo;
    [SerializeField] protected EnemyAttackSO _enemyAttackSo;

    private EnemyPoolEvent _enemyPoolEvent;
    
    [Inject]
    protected void Construct(EnemyPoolEvent enemyPoolEvent)
    {
        _enemyPoolEvent = enemyPoolEvent;
        SetEnemyStats();
    }

    private void SetEnemyStats()
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
        _enemyPoolEvent.FireDeactivated(this);
    }
}
