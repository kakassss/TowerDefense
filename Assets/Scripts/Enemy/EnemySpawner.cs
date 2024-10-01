using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyDefenceSO _enemyDefenceSo;
    [SerializeField] private EnemyAttackSO _enemyAttackSo;
    [SerializeField] private Transform position;
    
    private IEnemy _enemy;

    private void Start()
    {
        _enemy = new GoblinEnemy(_enemyDefenceSo,_enemyAttackSo);
        Debug.Log("gobling health" + _enemy.Health.GetCurrentHealth);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _enemy.Health.Damage(5);
            Debug.Log("goblingxd " + _enemy.Health.GetCurrentHealth);
        }
    }
}