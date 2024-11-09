using UnityEngine;
using Zenject;

public class GhostBuildManager
{
    private GridEntitySO _gridEntitySo;
    private GhostObjectReceiver _ghostObjectReceiver;
    private Utils _utils;
    private IInstantiator _instantiator;
    
    [Inject]
    private void Construct(
         GridEntitySO gridEntitySo, Utils utils, GhostObjectReceiver ghostObjectReceiver,
         IInstantiator instantiator)
    {
        _gridEntitySo = gridEntitySo;
        _ghostObjectReceiver = ghostObjectReceiver;
        _utils = utils;
        _instantiator = instantiator;
    }
    
    public void BuildAction()
    {
        SetGhostObject();
    }

    private void SetGhostObject()
    {
        _ghostObjectReceiver.GridIndexX = _gridEntitySo.X;
        _ghostObjectReceiver.GridIndexZ = _gridEntitySo.Z;

        _ghostObjectReceiver.GameObject = _instantiator.InstantiatePrefab(_gridEntitySo.GhostObject.GhostGO);
        _ghostObjectReceiver.GameObject.transform.position = _utils.GetValidPositionWithLayerMask();
    }
}