using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildButtonManager : MonoBehaviour
{
    [SerializeField] private List<BuildSelectUI> _buildButtons;
    [SerializeField] private Transform _spawnPos;
    
    private IInstantiator _instantiator;

    [Inject]
    private void Construct(IInstantiator instantiator)
    {
        _instantiator = instantiator;
    }

    private void Awake()
    {
        for (int i = 0; i < _buildButtons.Count; i++)
        {
            _instantiator.InstantiatePrefab(_buildButtons[i].gameObject, _spawnPos);
        }
    }
}



