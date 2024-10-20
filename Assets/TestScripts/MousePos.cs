
using UnityEngine;

public class MousePos : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;
    
    private Ray _ray;
    
    private void GetValidPosition()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out RaycastHit hit,float.MaxValue,_layerMask))
        {
            transform.position = hit.point;
        }
    }
    
    private void Update()
    {
        GetValidPosition();
    }
}
