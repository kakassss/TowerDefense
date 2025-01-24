using UnityEngine;
using Zenject;

public class BuildButtonManager : MonoBehaviour
{
    [SerializeField] private BuildSelectUI _buildButtons;
    [SerializeField] private Transform _spawnPos;
    
    private IInstantiator _instantiator;
    private GridEntitySO _gridEntity;
    
    [Inject]
    private void Construct(IInstantiator instantiator, GridEntitySO gridEntity)
    {
        _instantiator = instantiator;
        _gridEntity = gridEntity;
    }

    private void Awake()
    {
        for (int i = 0; i < _gridEntity.BaseObjects.Count; i++)
        {
            BuildUI buildUI = new BuildUI(i);
            BuildSelectUI button  = _instantiator.InstantiatePrefabForComponent<BuildSelectUI>(_buildButtons, _spawnPos);
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



