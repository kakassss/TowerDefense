using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BaseObjectPool<T> where T : Component
{
    protected List<T> _poolObjects;
    protected IInstantiator _instantiator;

    protected BaseObjectPool(IInstantiator instantiator)
    {
        _instantiator = instantiator;
    }
    
    protected void SetActiveStateObjects()
    {
        foreach (var poolObject in _poolObjects)
        {
            poolObject.gameObject.SetActive(false);
        }
    }
}
