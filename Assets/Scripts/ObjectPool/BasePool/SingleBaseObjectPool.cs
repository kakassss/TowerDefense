﻿using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SingleBaseObjectPool<T> : BaseObjectPool<T> where T : Component
{
    private readonly GameObject _prefab;
    private readonly Transform _spawnParent;
    private readonly int _poolSize;

    protected SingleBaseObjectPool(IInstantiator instantiator, GameObject prefab, Transform spawnParent, int poolSize)
        : base(instantiator)
    {
        _instantiator = instantiator;
        _prefab = prefab;
        _spawnParent = spawnParent;
        _poolSize = poolSize;
     
        SinglePrefabObjectPool(_prefab,_spawnParent,_poolSize);
    }

    private void SinglePrefabObjectPool(GameObject prefab,Transform parent, int poolSize)
    {
        _singlePoolObjects = new List<T>();
        
        for (int i = 0; i < poolSize; i++)
        { 
            _singlePoolObjects.Add(_instantiator.InstantiatePrefabForComponent<T>(prefab, parent));
        }
        
        SetSinglePoolActiveStateObjects();
    }

    public T GetAvailableObject()
    {
        _singlePoolObjects.RemoveAt(0);
        _singlePoolObjects[0].gameObject.SetActive(true);
        return _singlePoolObjects[0];
    }

    protected void ReturnObjectsToPool(T pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        _singlePoolObjects.Add(pooledObject);
    }
}