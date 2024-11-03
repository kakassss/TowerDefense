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
    
    public void BuildAction(Vector3 worldPos)
    {
        _ghostObjectReceiver.GameObject = Object.Instantiate(_gridEntitySo.GhostObject.GhostGO,
            _utils.GetValidPositionWithLayerMask(),Quaternion.identity);
        _ghostObjectReceiver.GridIndexX = _gridEntitySo.X;
        _ghostObjectReceiver.GridIndexZ = _gridEntitySo.Z;
        
        
        _cellManager.GetXZ(worldPos,out var x, out var z);
        
        for (int i = 0; i < _gridEntitySo.X; i++)
        {
            for (int j = 0; j < _gridEntitySo.Z; j++)
            {
                if ( x + i >= 0 && z + j >= 0 && x + i < _cellManager.Width && z + j < _cellManager.Height)
                {
                    var buildCell = _cellManager.Grid[x + i, z + j].Slot;

                    if (buildCell.IsFull != true) continue;
                    
                    //Burada rengini değiştireceksin
                    Debug.Log("Invalid position");
                }
            }
        }
        
    }
}