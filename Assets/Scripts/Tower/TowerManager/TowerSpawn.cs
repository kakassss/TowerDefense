using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class TowerSpawn : IDisposable
{
    private Ray _ray;
    private Camera _camera;
    private Vector3 _spawnPos;
    private LayerMask _layerMask;

    private InputActions _inputActions;
    private TowerEvents _towerEvents;
    private TowerPrefabSO _towerPrefabSo;
    private CellManager _cellManager;
    private BuildManager _buildManager;
    private GhostBuildManager _ghostBuildManager;
    
    private GridEntitySO _gridEntitySo;
    private Utils _utils;
    
    [Inject]
    private void Construct(
        TowerEvents towerEvents, TowerPrefabSO towerPrefabSo, Utils utils,
        LayerMask layerMask, InputActions inputActions, Camera camera,
        CellManager cellManager, BuildManager buildManager, GhostBuildManager ghostBuildManager)
    {
        _towerPrefabSo = towerPrefabSo;
        _towerEvents = towerEvents;
        _cellManager = cellManager;
        _buildManager = buildManager;
        _ghostBuildManager = ghostBuildManager;
        _utils = utils;
        
        _layerMask = layerMask;
        _camera = camera;
        _inputActions = inputActions;
        
        _inputActions.SpawnInputAddAction(Spawn);
        _inputActions.GhostSpawnInputAddAction(GhostSpawn);
    }

    private void GhostSpawn()
    {
        _spawnPos = _utils.GetValidPositionWithLayerMask(_camera,_layerMask);
        if(_spawnPos == Vector3.zero) return;
        if(_cellManager.CheckCellState(_spawnPos) == true) return;
        
        _ghostBuildManager.BuildAction(_spawnPos);
    }
    
    private void Spawn()
    {
        _spawnPos = _utils.GetValidPositionWithLayerMask(_camera,_layerMask);
        if(_spawnPos == Vector3.zero) return;
        if(_cellManager.CheckCellState(_spawnPos) == true) return;
        
        
        _buildManager.BuildAction(_spawnPos);
        //_cellManager.BuildGridEntity(_spawnPos,_gridEntitySo,_towerPrefabSo.AllTowers[0].gameObject);
        return;
        _spawnPos = _cellManager.GetCellMidPointPosition(_spawnPos);

        //Debug.Log("midPoint spawn pos " + _spawnPos);
        var newTower = Object.Instantiate(_towerPrefabSo.AllTowers[0].gameObject, _spawnPos,Quaternion.identity);
        _cellManager.SetCellAtIndex(_spawnPos,newTower);

        if (!newTower.TryGetComponent<ITower>(out ITower tower)) return; // belki scriptableobjeye direkt olarak interfaceli olarak ala
        _towerEvents.TowerSpawnedTriggerAction(tower); 
    }
    
    public void Dispose()
    {
        _inputActions.SpawnInputRemoveAction(Spawn);
        _inputActions.GhostSpawnInputRemoveAction(GhostSpawn);
    }
}
