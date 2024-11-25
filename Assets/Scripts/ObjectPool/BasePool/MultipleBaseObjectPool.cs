using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class MultipleBaseObjectPool<T> : BaseObjectPool<T> where T : Component
{
    private readonly List<T> _prefabs;
    private readonly List<int> _indexes; 
    private readonly List<int> _poolSize;
    private readonly Transform _parent;
    
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

    public T GetPoolData(int poolID)
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

    protected void ReturnPoolData(T poolData, EnemyID poolID)
    {
        poolData.gameObject.SetActive(false);
        BaseObjectPoolData<T> oldData = new BaseObjectPoolData<T>(poolData, poolID.ID);
        _multiplePoolDataList.Add(oldData);
    }
}

