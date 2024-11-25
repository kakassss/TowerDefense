using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyPool : MultipleBaseObjectPool<BaseEnemy>, IDisposable
{
    private EnemyPoolEvent _enemyPoolEvent;
    
    protected EnemyPool(IInstantiator instantiator, List<BaseEnemy> prefabs, Transform parent, List<int> poolSize, List<int> indexes, EnemyPoolEvent enemyPoolEvent) 
        : base(instantiator, prefabs, parent, poolSize, indexes)
    {
        _enemyPoolEvent = enemyPoolEvent;
        
        _enemyPoolEvent.AddDeactivatedListener(ReturnPoolData);
    }

    public void Dispose()
    {
        _enemyPoolEvent.RemoveDeactivatedListener(ReturnPoolData);
    }
}
