using UnityEngine;
using Zenject;

public class EnemyWave : MonoBehaviour
{
    private EnemyPool _enemyPool;
    private EnemyID _enemyID;

    [Inject]
    private void Construct(EnemyPool enemyPool)
    {
        _enemyPool = enemyPool;

        _enemyID = new EnemyID(1);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var aa = _enemyPool.GetPoolData(1);
        }
    }
}
