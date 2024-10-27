using UnityEngine;

public class Utils
{
    public Vector3 GetValidPositionWithLayerMask(Camera camera,LayerMask layerMask)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit,float.MaxValue, layerMask) ? hit.point : Vector3.zero;
    }
    
    public Vector3 GetValidPosition(Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit,float.MaxValue) ? hit.point : Vector3.zero;
    }
    
}