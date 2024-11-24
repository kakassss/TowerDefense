using System;
using UnityEngine;
using Zenject;

public class ProjectilePool : BasePool<BaseProjectile>, IDisposable
{
    private ProjectilePoolEvent _projectilePoolEvent;
    public ProjectilePool(IInstantiator instantiator, GameObject prefab, Transform spawnParent, int poolSize, ProjectilePoolEvent projectilePoolEvent)
        : base(instantiator, prefab, spawnParent, poolSize)
    {
        _projectilePoolEvent = projectilePoolEvent;
        
        _projectilePoolEvent.AddDeactivatedListener(_pool.ReturnObjectsToPool);
    }

    public void Dispose()
    {
        _projectilePoolEvent.RemoveDeactivatedListener(_pool.ReturnObjectsToPool);
    }
}