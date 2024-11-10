using UnityEngine;
using Zenject;

public class GhostBuildManager
{
    private BuildSelectManager _buildSelectManager;
    private GhostObjectReceiver _ghostObjectReceiver;
    private Utils _utils;
    private IInstantiator _instantiator;
    
    [Inject]
    private void Construct(
          Utils utils, GhostObjectReceiver ghostObjectReceiver, IInstantiator instantiator,
          BuildSelectManager buildSelectManager)
    {
        _ghostObjectReceiver = ghostObjectReceiver;
        _utils = utils;
        _instantiator = instantiator;
        _buildSelectManager = buildSelectManager;
    }
    
    public void BuildAction()
    {
        SetGhostObject();
    }

    private void SetGhostObject()
    {
        if (_buildSelectManager.CurrentGridEntitySO == null)
        {
            Debug.LogError("Selected Entity is null");
            return;
        }

        var currentEntity = _buildSelectManager.CurrentGridEntitySO;
        
        _ghostObjectReceiver.GridIndexX = currentEntity.X;
        _ghostObjectReceiver.GridIndexZ = currentEntity.Z;

        _ghostObjectReceiver.GameObject = _instantiator.InstantiatePrefab(currentEntity.GhostObject.GhostGO);
        _ghostObjectReceiver.GameObject.transform.position = _utils.GetValidPositionWithLayerMask();
    }
}