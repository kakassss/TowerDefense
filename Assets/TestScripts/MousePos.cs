
using System;
using UnityEngine;
using Zenject;

public class MousePos : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;
    
    private Ray _ray;

    private TowerManager _towerManager;

    [Inject]
    private void Construct(TowerManager towerManager)
    {
        _towerManager = towerManager;
    }
    

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("total tower " + _towerManager.TotalTowers.Count);

            foreach (var t in _towerManager.TotalTowers)
            {
                Debug.Log("menacaaaaa menacağğğ " + t.Health.GetCurrentHealth);
            }
        }
        
        GetValidPosition();
    }
}
