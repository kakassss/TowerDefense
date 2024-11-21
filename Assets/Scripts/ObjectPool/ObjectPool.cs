using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPool<T>
{
    private List<T> _objects;
    private IInstantiator _instantiator;
    
    public ObjectPool(IInstantiator instantiator)
    {
        _instantiator = instantiator;
    }
    
    public void InitObjectPool(GameObject prefab,Transform spawnpos, int count)
    {
        _objects = new List<T>();
        
        for (int i = 0; i < count; i++)
        { 
            var go = _instantiator.InstantiatePrefabForComponent<T>(prefab, spawnpos); 
            _objects.Add(go);
        }
    }

    public T GetAvailableObjects()
    {
        _objects.RemoveAt(0);
        return _objects[0];
    }

    public void ReturnObjectsToPool(T pooledObject)
    {
        _objects.Add(pooledObject);
    }
}
