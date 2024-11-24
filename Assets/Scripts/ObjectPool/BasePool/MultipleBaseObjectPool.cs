using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MultipleBaseObjectPool<T> : BaseObjectPool<T> where T : Component
{
    private List<T> _prefabs;
    private List<int> _indexes; 
    private List<int> _poolSize;
    private Transform _parent;
    
    protected MultipleBaseObjectPool(IInstantiator instantiator, List<T> prefabs,Transform parent, List<int> poolSize, List<int> indexes) 
        : base(instantiator)
    {
        _instantiator = instantiator;
        _prefabs = prefabs;
        _parent = parent;
        _poolSize = poolSize;
        _indexes = indexes;
        
        MultiplePrefabObjectPool(_prefabs, _parent, _poolSize, _indexes);
    }

    private void MultiplePrefabObjectPool(List<T> prefabs,Transform parent, List<int> poolSize, List<int> index)
    {
        _poolObjects = new List<T>();
        
        for (int i = 0; i < index.Count; i++)
        {
            for (int j = 0; j < poolSize[i]; j++)
            { 
                _poolObjects.Add(_instantiator.InstantiatePrefabForComponent<T>(prefabs[i], parent));
            }    
        }
        
        SetActiveStateObjects();
    }
    
    public T GetAvailableObjects(T baseObject)
    {
        _poolObjects.Remove(baseObject);
        baseObject.gameObject.SetActive(true);
        return baseObject;
    }

    protected void ReturnObjectsToPool(T pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        _poolObjects.Add(pooledObject);
    }
    
}