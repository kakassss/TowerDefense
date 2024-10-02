using UnityEngine;

public class EnemyGoblin : Enemy
{
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
        
        //_enemy = new BaseEnemy(Health,Defence,Attack,_enemyDefenceSo,_enemyAttackSo);
        Debug.Log("gobling health" + Health.GetCurrentHealth);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    
}