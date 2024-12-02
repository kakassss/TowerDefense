using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class MultipleBaseObjectPool<T> : BaseObjectPool where T : Component
{
    private List<BaseObjectPoolData<T>> _multiplePoolDataList;
    
    private readonly List<T> _prefabs;
    private readonly List<int> _indexes; 
    private readonly List<int> _poolSize;
    
    protected MultipleBaseObjectPool(IInstantiator instantiator, List<T> prefabs,Transform spawnParent, List<int> poolSize, List<int> indexes) 
        : base(instantiator)
    {
        _instantiator = instantiator;
        _prefabs = prefabs;
        _spawnParent = spawnParent;
        _poolSize = poolSize;
        _indexes = indexes;
        
        MultiplePrefabObjectPool(_prefabs, _spawnParent, _poolSize, _indexes);
    }

    private void MultiplePrefabObjectPool(List<T> prefabs,Transform parent, List<int> poolSize, List<int> index)
    {
        _multiplePoolDataList = new List<BaseObjectPoolData<T>>();
        
        for (int i = 0; i < index.Count; i++)
        {
            for (int j = 0; j < poolSize[i]; j++)
            { 
                BaseObjectPoolData<T> poolData = 
                    new BaseObjectPoolData<T>(_instantiator.InstantiatePrefabForComponent<T>(prefabs[i], parent),i);
                
                _multiplePoolDataList.Add(poolData);
            }    
        }
        
        SetMultiplePoolObjects();
    }
    
    private void SetMultiplePoolObjects()
    {
        foreach (var poolData in _multiplePoolDataList)
        {
            poolData.prefab.gameObject.SetActive(false);
        }
    }
    
    public T GetObjectFromPool(int poolID, Vector3 position)
    {
        var poolList = _multiplePoolDataList.Where(data => data.ID == poolID);
        foreach (var data in poolList)
        {
            _multiplePoolDataList.Remove(data);
            data.prefab.gameObject.SetActive(true);
            data.prefab.transform.position = position;
            return data.prefab;
        }
        Debug.LogError("Insufficient pool data for this pool");
        return null;
    }
    
    public T GetObjectFromPool(int poolID)
    {
        var poolList = _multiplePoolDataList.Where(data => data.ID == poolID);
        foreach (var data in poolList)
        {
            _multiplePoolDataList.Remove(data);
            data.prefab.gameObject.SetActive(true);
            return data.prefab;
        }
        Debug.LogError("Insufficient pool data for this pool");
        return null;
    }

    protected void ReturnObjectToPool(T poolData, EnemyID poolID)
    {
        poolData.gameObject.SetActive(false);
        poolData.transform.position = Vector3.zero;
        
        BaseObjectPoolData<T> oldData = new BaseObjectPoolData<T>(poolData, poolID.ID);
        _multiplePoolDataList.Add(oldData);
    }
}
public struct BaseObjectPoolData<T> : IEquatable<BaseObjectPoolData<T>>
{
    public T prefab;
    public int ID;

    public BaseObjectPoolData(T prefab, int ID)
    {
        this.prefab = prefab;
        this.ID = ID;
    }

    public bool Equals(BaseObjectPoolData<T> other)
    {
        return EqualityComparer<T>.Default.Equals(prefab, other.prefab) && ID == other.ID;
    }

    public override bool Equals(object obj)
    {
        return obj is BaseObjectPoolData<T> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(prefab, ID);
    }
}
