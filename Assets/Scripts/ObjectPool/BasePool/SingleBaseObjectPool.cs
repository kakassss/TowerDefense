using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SingleBaseObjectPool<T> : BaseObjectPool<T> where T : Component
{
    private GameObject _prefab;
    private Transform _spawnParent;
    private int _poolSize;
    private IInstantiator _instantiator;
    
    public SingleBaseObjectPool(IInstantiator instantiator, GameObject prefab, Transform spawnParent, int poolSize) : base(instantiator)
    {
        _instantiator = instantiator;
        _prefab = prefab;
        _spawnParent = spawnParent;
        _poolSize = poolSize;
     
        SinglePrefabObjectPool(_prefab,_spawnParent,_poolSize);
    }

    public void SinglePrefabObjectPool(GameObject prefab,Transform parent, int poolSize)
    {
        _poolObjects = new List<T>();
        
        for (int i = 0; i < poolSize; i++)
        { 
            _poolObjects.Add(_instantiator.InstantiatePrefabForComponent<T>(prefab, parent));
        }
        
        SetActiveStateObjects();
    }

    public T GetAvailableObjects()
    {
        _poolObjects.RemoveAt(0);
        _poolObjects[0].gameObject.SetActive(true);
        return _poolObjects[0];
    }

    public void ReturnObjectsToPool(T pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        _poolObjects.Add(pooledObject);
    }
}