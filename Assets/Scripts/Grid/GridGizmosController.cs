using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;


public class GridGizmosController : MonoBehaviour
{
    [SerializeField] private GameObject gridPrefab;
    
    private CellManager _cellManager;

    private CellManager _tempCellManager;
    private Utils _utils;
    
    private Vector3 _originPosition = Vector3.zero;
    [SerializeField] private int _gridSize;
    [SerializeField] private int _cellSize;
   
    
    [Inject]
    private void Construct(CellManager cellManager, Utils utils)
    {
        _cellManager = cellManager;
        _utils = utils;
    }
    
    [InfoBox("You can use after changing gizmos object transform position")]
    [Button("Calculate Grid Gizmos", ButtonSizes.Medium, ButtonStyle.Box)]
    private void OnValidate()
    {
        _originPosition.x = -(_gridSize * _cellSize) / 2 + transform.position.x;
        _originPosition.y = 0.1f;
        _originPosition.z = -(_gridSize * _cellSize) / 2 + transform.position.z;
        //_tempCellManager = new CellManager(_gridSize,_gridSize,_cellSize,_originPosition,_utils);
    }
    
    // private void Update()
    // {
    //     Debug.Log("onur + " + _cellManager.GetXZ(_utils.GetValidPosition()));
    // }

    private (int x, int z) _tuple;
    // private void OnDrawGizmos()
    // {
    //     if(Application.isPlaying == false) return;
    //     
    //     Gizmos.color = Color.red;
    //     // for (int i = 0; i < _gridSize; i++)
    //     // {
    //     //     for (int j = 0; j < _gridSize; j++)
    //     //     {
    //     //         Gizmos.DrawLine(
    //     //             _tempCellManager.GetWorldPosition(j, i),
    //     //             _tempCellManager.GetWorldPosition(j + 1, i));
    //     //
    //     //         Gizmos.DrawLine(
    //     //             _tempCellManager.GetWorldPosition(j, i + 1),
    //     //             _tempCellManager.GetWorldPosition(j,i));   
    //     //     }
    //     // }
    //     //
    //     // Gizmos.DrawLine(
    //     //     _tempCellManager.GetWorldPosition(0, _gridSize),
    //     //     _tempCellManager.GetWorldPosition(_gridSize, _gridSize));
    //     //
    //     // Gizmos.DrawLine(
    //     //     _tempCellManager.GetWorldPosition(_gridSize,0),
    //     //     _tempCellManager.GetWorldPosition(_gridSize, _gridSize));
    //     //
    //     for (int i = 0; i < _cellManager.Width; i++)
    //     {
    //         for (int j = 0; j < _cellManager.Height; j++)
    //         {
    //             Gizmos.DrawCube(
    //                 _cellManager.GetWorldPosition(j, i) + new Vector3(0,0.2f,0), new Vector3(0.5f,0.5f,0.5f));
    //     
    //             Gizmos.DrawCube(
    //                 _cellManager.GetWorldPosition(j, i + 1) + new Vector3(0,0.2f,0), new Vector3(0.5f,0.5f,0.5f));   
    //         }
    //     }
    //     
    //     
    //     
    //     
    //     for (int i = 0; i < _cellManager.Width; i++)
    //     {
    //         for (int j = 0; j < _cellManager.Height; j++)
    //         {
    //             Gizmos.DrawLine(
    //                 _cellManager.GetWorldPosition(j, i) + new Vector3(0,0.2f,0),
    //                 _cellManager.GetWorldPosition(j + 1, i) + new Vector3(0,0.2f,0));
    //     
    //             Gizmos.DrawLine(
    //                 _cellManager.GetWorldPosition(j, i + 1) + new Vector3(0,0.2f,0),
    //                 _cellManager.GetWorldPosition(j,i) + new Vector3(0,0.2f,0));   
    //         }
    //     }
    //     
    //     Gizmos.DrawLine(
    //         _cellManager.GetWorldPosition(0, _cellManager.Height),
    //         _cellManager.GetWorldPosition(_cellManager.Width, _cellManager.Height));
    //     
    //     Gizmos.DrawLine(
    //         _cellManager.GetWorldPosition(_cellManager.Width,0),
    //         _cellManager.GetWorldPosition(_cellManager.Width, _cellManager.Height));
    // }
    

}