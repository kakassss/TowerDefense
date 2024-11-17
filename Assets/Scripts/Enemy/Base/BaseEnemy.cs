using UnityEngine;
using Zenject;

public abstract class BaseEnemy : MonoBehaviour,IEnemy
{
    public BaseHealth Health { get; protected set;}
    public BaseEnemyDefence Defence { get; protected set; }
    public BaseEnemyAttack Attack { get; protected set;}
    public Transform Transform => transform;
    
    [SerializeField] protected EnemyDefenceSO _enemyDefenceSo;
    [SerializeField] protected EnemyAttackSO _enemyAttackSo;
    
    [Inject]
    protected void Construct()
    {
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
}
