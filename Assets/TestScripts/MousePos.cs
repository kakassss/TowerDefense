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
    
    [Inject]
    private void Construct(Utils utils,GhostObjectReceiver ghostObjectReceiver)
    {
        _utils = utils;
        _ghostObjectReceiver = ghostObjectReceiver;
    }
    
    private void Update()
    {
        transform.position = _utils.GetValidPositionWithLayerMask();
        if(_ghostObjectReceiver.GameObject == null) return;
        _ghostObjectReceiver.GameObject.transform.position = transform.position;
    }
}
