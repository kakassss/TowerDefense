using System;
using UnityEngine;
using Zenject;

public class EnemyPool : BasePool<BaseEnemy>, IDisposable
{
    private EnemyPoolEvent _enemyPoolEvent;
    public EnemyPool(IInstantiator instantiator, GameObject prefab, Transform spawnParent, int poolSize, EnemyPoolEvent enemyPoolEvent)
        : base(instantiator, prefab, spawnParent, poolSize)
    {
        _enemyPoolEvent = enemyPoolEvent;
        
        _enemyPoolEvent.AddDeactivatedListener(_pool.ReturnObjectsToPool);
    }

    public void Dispose()
    {
        _enemyPoolEvent.RemoveDeactivatedListener(_pool.ReturnObjectsToPool);
    }
}
