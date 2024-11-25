using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BaseObjectPool<T> where T : Component
{
    protected List<T> _singlePoolObjects;
    protected List<BaseObjectPoolData<T>> _multiplePoolDataList;
    protected IInstantiator _instantiator;

    protected BaseObjectPool(IInstantiator instantiator)
    {
        _instantiator = instantiator;
    }

    protected void SetMultiplePoolObjects()
    {
        foreach (var poolData in _multiplePoolDataList)
        {
            poolData.prefab.gameObject.SetActive(false);
        }
    }
    
    protected void SetSinglePoolActiveStateObjects()
    {
        foreach (var poolObject in _singlePoolObjects)
        {
            poolObject.gameObject.SetActive(false);
        }
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
