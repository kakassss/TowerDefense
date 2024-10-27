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
    private Utils _utils;
    
    [Inject]
    private void Construct(
        TowerEvents towerEvents, TowerPrefabSO towerPrefabSo, Utils utils,
        LayerMask layerMask, InputActions inputActions, Camera camera)
    {
        _towerPrefabSo = towerPrefabSo;
        _towerEvents = towerEvents;
        _utils = utils;
        
        _layerMask = layerMask;
        _camera = camera;
        _inputActions = inputActions;
        
        _inputActions.SpawnInputAddAction(Spawn);
    }
    
    private void Spawn()
    {
        _spawnPos = _utils.GetValidPositionWithLayerMask(_camera,_layerMask);
        if(_spawnPos == Vector3.zero) return;
        
        var newTower = Object.Instantiate(_towerPrefabSo.AllTowers[0].gameObject, _spawnPos,Quaternion.identity);

        if (!newTower.TryGetComponent<ITower>(out ITower tower)) return; // belki scriptableobjeye direkt olarak interfaceli olarak ala
        _towerEvents.TowerSpawnedTriggerAction(tower); 
        
        //Debug.Log("tower list " + _itowerList.Count);
    }

    public void Dispose()
    {
        _inputActions.SpawnInputRemoveAction(Spawn);
    }
}
