using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class TowerSpawn : IDisposable
{
    private Vector3 _spawnPos;

    private InputActions _inputActions;
    private TowerEvents _towerEvents;
    private CellManager _cellManager;
    private BuildManager _buildManager;
    private GhostBuildManager _ghostBuildManager;
    
    private GridEntitySO _gridEntitySo;
    private Utils _utils;
    
    private TowerSpawn(
        TowerEvents towerEvents, Utils utils, InputActions inputActions,
        CellManager cellManager, BuildManager buildManager, GhostBuildManager ghostBuildManager)
    {
        _towerEvents = towerEvents;
        _cellManager = cellManager;
        _buildManager = buildManager;
        _ghostBuildManager = ghostBuildManager;
        _utils = utils;
        
        _inputActions = inputActions;
        
        _inputActions.SpawnInputAddAction(Spawn);
        _inputActions.GhostSpawnInputAddAction(GhostSpawn);
    }

    private void GhostSpawn()
    {
        _spawnPos = _utils.GetValidPositionWithLayerMask();
        if(_spawnPos == Vector3.zero) return;
        _ghostBuildManager.BuildAction();
    }
    
    private void Spawn()
    {
        _spawnPos = _utils.GetValidPositionWithLayerMask();
        if(_spawnPos == Vector3.zero) return;
        if(_cellManager.CheckCellState(_spawnPos) == true) return;
        
        
        _buildManager.BuildAction(_spawnPos);
        //_cellManager.BuildGridEntity(_spawnPos,_gridEntitySo,_towerPrefabSo.AllTowers[0].gameObject);
        //_spawnPos = _cellManager.GetCellMidPointPosition(_spawnPos);

        //Debug.Log("midPoint spawn pos " + _spawnPos);
        //var newTower = Object.Instantiate(_towerPrefabSo.AllTowers[0].gameObject, _spawnPos,Quaternion.identity);
        //_cellManager.SetCellAtIndex(_spawnPos,newTower);

        //if (!newTower.TryGetComponent<ITower>(out ITower tower)) return; // belki scriptableobjeye direkt olarak interfaceli olarak ala
        //_towerEvents.TowerSpawnedTriggerAction(tower); 
    }
    
    public void Dispose()
    {
        _inputActions.SpawnInputRemoveAction(Spawn);
        _inputActions.GhostSpawnInputRemoveAction(GhostSpawn);
    }
}
