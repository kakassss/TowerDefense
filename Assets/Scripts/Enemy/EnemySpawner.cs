using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySO _enemySo;
    [SerializeField] private Transform position;
    
    private IEnemy _enemy;

    private void Start()
    {
        _enemy = new GoblinEnemy(_enemySo);
        _enemySo.Prefab = _enemySo.Prefab;
        
        Debug.Log("goblin has created " + _enemy);
        Debug.Log("goblin has fire resistance " + _enemy.Defence._so.FireDefence);
    }
}