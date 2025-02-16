using UnityEngine;
using Zenject;

public class GhostBuildManager
{
    private BuildObjectReceiver _buildObjectReceiver;
    private GhostObjectReceiver _ghostObjectReceiver;
    private Utils _utils;
    private IInstantiator _instantiator;
    
    [Inject]
    private void Construct(
          Utils utils, GhostObjectReceiver ghostObjectReceiver, IInstantiator instantiator,
          BuildObjectReceiver buildObjectReceiver)
    {
        _ghostObjectReceiver = ghostObjectReceiver;
        _utils = utils;
        _instantiator = instantiator;
        _buildObjectReceiver = buildObjectReceiver;
    }
    
    public void BuildAction()
    {
        SetGhostObject();
    }

    private void SetGhostObject()
    {
        if (_ghostObjectReceiver.GameObject != null)
        {
            //TODO: could be basic object pooling
            Object.Destroy(_ghostObjectReceiver.GameObject);
        }
        
        if (_buildObjectReceiver.CurrentGridEntitySO == null)
        {
            Debug.LogError("Selected Entity is null");
            _ghostObjectReceiver.GhostObjectValid = false;
            return;
        }

        var currentEntity = _buildObjectReceiver.CurrentGridEntitySO;
        
        _ghostObjectReceiver.GridIndexX = currentEntity.X;
        _ghostObjectReceiver.GridIndexZ = currentEntity.Z;

        _ghostObjectReceiver.GameObject = _instantiator.InstantiatePrefab(currentEntity.GhostObject.GhostGO);
        _ghostObjectReceiver.GameObject.transform.position = _utils.GetValidPositionWithLayerMask();
        _ghostObjectReceiver.GhostObjectValid = true;
    }
}