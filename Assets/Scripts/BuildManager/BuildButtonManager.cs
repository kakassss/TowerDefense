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
            BuildUI buildUI = new BuildUI(i);
            BuildSelectUI button  = _instantiator.InstantiatePrefabForComponent<BuildSelectUI>(_buildButtons[i], _spawnPos);
            button.SetBuildButton(buildUI);
        }
    }
}

public struct BuildUI
{
    public int TowerIndex;
    
    public BuildUI(int towerIndex)
    {
        TowerIndex = towerIndex;
    }
}



