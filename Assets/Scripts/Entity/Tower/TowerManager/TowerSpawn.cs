using System;
using UnityEngine;

public class TowerSpawn : BaseSpawner, IDisposable
{
    private TowerEvents _towerEvents;
    private CellManager _cellManager;
    private BuildManager _buildManager;
    
    private TowerSpawn(
        TowerEvents towerEvents, Utils utils, BuildingInputEvents buildingInputEvents,
        CellManager cellManager, BuildManager buildManager) : base(utils,buildingInputEvents)
    {
        _towerEvents = towerEvents;
        _cellManager = cellManager;
        _buildManager = buildManager;
        
        BuildingInputEvents.SpawnInputAddAction(Spawn);
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
        BuildingInputEvents.SpawnInputRemoveAction(Spawn);
    }
}