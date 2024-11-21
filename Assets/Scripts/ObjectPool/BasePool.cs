using UnityEngine;
using Zenject;

public class BasePool<T>
{
    protected ObjectPool<T> _pool;
    
    protected GameObject _prefab;
    protected Transform _spawnParent;
    protected int _poolSize;
    protected IInstantiator _instantiator;
    
    protected BasePool(IInstantiator instantiator, GameObject prefab, Transform spawnParent, int poolSize)
    {
        _instantiator = instantiator;
        _prefab = prefab;
        _spawnParent = spawnParent;
        _poolSize = poolSize;
        
        _pool = new ObjectPool<T>(_instantiator);
        _pool.InitObjectPool(_prefab,_spawnParent,_poolSize);
    }
}