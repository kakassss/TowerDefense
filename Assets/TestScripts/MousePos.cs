using UnityEngine;
using Zenject;

public class GhostObjectReceiver
{
    public GameObject GameObject;
}

public class MousePos : MonoBehaviour
{
    private Utils _utils;
    private GhostObjectReceiver _ghostObjectReceiver;
    private CellManager _cellManager;
    
    [Inject]
    private void Construct(Utils utils,GhostObjectReceiver ghostObjectReceiver,CellManager cellManager)
    {
        _utils = utils;
        _ghostObjectReceiver = ghostObjectReceiver;
        _cellManager = cellManager;
    }
    
    private void Update()
    {
        transform.position = _utils.GetValidPositionWithLayerMask();
        if(_ghostObjectReceiver.GameObject == null) return;
        var mouseCell = _cellManager.GetCellAtIndex(_ghostObjectReceiver.GameObject.transform.position);

        if (mouseCell == null)
        {
            _ghostObjectReceiver.GameObject.transform.position = transform.position;
            return;
        }
        _cellManager.GetXZ(_utils.GetValidPositionWithLayerMask(),out var X, out var Z);

        _ghostObjectReceiver.GameObject.transform.position = _cellManager.GetWorldPosition(X, Z);

    }
}
