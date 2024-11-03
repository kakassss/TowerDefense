using UnityEngine;

public class Utils
{
    private Camera _camera;
    private LayerMask _layerMask;
    
    private Utils(Camera camera, LayerMask layerMask)
    {
        _camera = camera;
        _layerMask = layerMask;
    }

    
    
    public Vector3 GetValidPositionWithLayerMask()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit,float.MaxValue, _layerMask) ? hit.point : Vector3.zero;
    }
    
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
    
    //-3.14 -> -3
    //-3.64 -> -4
    //3.14 -> 3
    //3.65 -> 4
    public int CustomRound(float value)
    {
        return (int)(value >= 0 ? value + 0.5f : value - 0.5f);
    }
    
}