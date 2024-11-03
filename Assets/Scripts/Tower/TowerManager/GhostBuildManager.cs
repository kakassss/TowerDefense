using UnityEngine;
using Zenject;

public class GhostBuildManager
{
    private CellManager _cellManager;
    private GridEntitySO _gridEntitySo;
    private GhostObjectReceiver _ghostObjectReceiver;
    private Utils _utils;

    
    [Inject]
    private void Construct(
        CellManager cellManager,GridEntitySO gridEntitySo, Utils utils,
        GhostObjectReceiver ghostObjectReceiver)
    {
        _cellManager = cellManager;
        _gridEntitySo = gridEntitySo;
        _ghostObjectReceiver = ghostObjectReceiver;
        _utils = utils;
    }
    
    public void BuildAction()
    {
        SetGhostObject();
    }

    private void SetGhostObject()
    {
        _ghostObjectReceiver.GameObject = Object.Instantiate(_gridEntitySo.GhostObject.GhostGO,
            _utils.GetValidPositionWithLayerMask(),Quaternion.identity);
        
        _ghostObjectReceiver.GridIndexX = _gridEntitySo.X;
        _ghostObjectReceiver.GridIndexZ = _gridEntitySo.Z;
        _ghostObjectReceiver.GreenMaterials = _gridEntitySo.GhostObject.GreenMaterials;
        _ghostObjectReceiver.RedMaterials = _gridEntitySo.GhostObject.RedMaterials;
        _ghostObjectReceiver.MeshRenderers = _gridEntitySo.GhostObject.GetMeshRenderers();
    }
}