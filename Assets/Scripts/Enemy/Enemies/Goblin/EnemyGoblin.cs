using UnityEngine;

public class EnemyGoblin : MonoBehaviour, IEnemy
{
    public BaseHealth Health { get; protected set;}
    public BaseEnemyDefence Defence { get; protected set; }
    public BaseEnemyAttack Attack { get; protected set;}
    public Transform Transform => transform;

    [SerializeField] private EnemyDefenceSO _enemyDefenceSo;
    [SerializeField] private EnemyAttackSO _enemyAttackSo;
    
    private void Start()
    {
        Defence = new BaseEnemyDefence
        {
            DefenceSo = _enemyDefenceSo
        };
        Attack = new BaseEnemyAttack(_enemyAttackSo);
        Health = new BaseHealth(100);
    }
}