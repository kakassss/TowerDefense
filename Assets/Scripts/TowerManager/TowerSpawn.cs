using System;
using System.Collections.Generic;
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
    private TowerManager _towerManager;
    
    [Inject]
    private void Construct(
        TowerEvents towerEvents,
        TowerPrefabSO towerPrefabSo,
        LayerMask layerMask,
        InputActions inputActions,
        TowerManager towerManager)
    {
        _towerEvents = towerEvents;
        _towerPrefabSo = towerPrefabSo;
        _layerMask = layerMask;
        _inputActions = inputActions;
        _towerManager = towerManager;
        
        
        _camera = Camera.main;
        
        _inputActions.SpawnInputAddAction(Spawn);
    }
    
    
    private void Spawn()
    {
        _spawnPos = GetValidPos();
        if(_spawnPos == Vector3.zero) return;
        
        var newTower = Object.Instantiate(_towerPrefabSo.AllTowers[0].gameObject, _spawnPos,Quaternion.identity);

        if (!newTower.TryGetComponent<ITower>(out ITower tower)) return; // belki scriptableobjeye direkt olarak interfaceli olarak alabiliriz
        
        
        _towerEvents.TowerSpawnedTriggerAction(tower); 
        
        




        //Debug.Log("tower list " + _itowerList.Count);
    }

    private Vector3 GetValidPos()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(_ray, out RaycastHit hit,float.MaxValue, _layerMask) ? hit.point : Vector3.zero;
    }

    public void Dispose()
    {
        _inputActions.SpawnInputRemoveAction(Spawn);
    }
}
