using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Utils
{
    private Camera _camera;
    private LayerMask _layerMask;
    
    private Utils(Camera camera, LayerMask layerMask)
    {
        _camera = camera;
        _layerMask = layerMask;
    }
    
    public void PrintListMemberNames<T>(List<T> list)
    {
        foreach (var data in list)
        {
            var nameProperty = typeof(T).GetProperty("Name");
            if (nameProperty != null)
            {
                var nameValue = nameProperty.GetValue(data)?.ToString();
                Debug.Log(nameValue);
            }
        }
    }

    public Transform GetMainCameraTransform()
    {
        return _camera.transform;
    }
    
    private PointerEventData m_PointerData;
    private List<RaycastResult> m_RaycastResults = new List<RaycastResult>();
    
    public bool IsRaycastHittingUIObject(Vector2 position)
    {
        if (m_PointerData == null)
            m_PointerData = new PointerEventData(EventSystem.current);
        m_PointerData.position = position;
        EventSystem.current.RaycastAll(m_PointerData, m_RaycastResults);
        return m_RaycastResults.Count > 0;
    }

    
    public BaseTower GetValidPositionWithLayerMask(int layerMask)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit,float.MaxValue, layerMask))
        {
            if (hit.collider.TryGetComponent<BaseTower>(out BaseTower tower))
            {
                return tower;
            }
        }
        return null;
        //return Physics.Raycast(ray, out RaycastHit hit,float.MaxValue, layerMask) ? hit.point : Vector3.zero;
    }
    
    //Using with building
    public Vector3 GetValidPositionWithLayerMask()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit,float.MaxValue, _layerMask) ? hit.point : Vector3.zero;
    }
    
    public Vector3 GetValidPositionWithLayerMask(LayerMask layerMask)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit,float.MaxValue, layerMask) ? hit.point : Vector3.zero;
    }
    
    public Vector3 GetValidPositionWithLayerMask(Camera camera,LayerMask layerMask)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit,float.MaxValue, layerMask) ? hit.point : Vector3.zero;
    }
    
    public Vector3 GetValidPosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
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