using UnityEngine;
using Zenject;

public class ProjectilePool : BasePool<BaseProjectile>
{
    public ProjectilePool(IInstantiator instantiator, GameObject prefab, Transform spawnParent, int poolSize)
        : base(instantiator, prefab, spawnParent, poolSize)
    {
    }
}