using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

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


public class BuildManager
{
    private CellManager _cellManager;
    private GridEntitySO _gridEntitySo;
    
    [Inject]
    private void Construct(CellManager cellManager,GridEntitySO gridEntitySo)
    {
        _cellManager = cellManager;
        _gridEntitySo = gridEntitySo;
    }
    
    
    public void BuildAction(Vector3 worldPos)
    {
        var mousePosCell = _cellManager.GetCellAtIndex(worldPos);
        
        if(mousePosCell == null) return;

        List<BuildMultipleCells> buildCells = new List<BuildMultipleCells>();

        _cellManager.GetXZ(worldPos,out var x, out var z);
        
        Debug.Log("X Z " + x + z);
        
        for (int i = 0; i < _gridEntitySo.X; i++)
        {
            for (int j = 0; j < _gridEntitySo.Z; j++)
            {
                if ( x + i >= 0 && z + j >= 0 && x + i < _cellManager.Width && z + j < _cellManager.Height)
                {
                    var buildCell = _cellManager.Grid[x + i, z + j];
                    if(buildCell.Slot.IsFull == true) return;
                
                    Debug.Log("buildCell " + (x+i) + " " + (z + j));
                    BuildMultipleCells buildableMultipleCells = new BuildMultipleCells(buildCell,_gridEntitySo.BuildObject, _cellManager.CellSize, _cellManager.OriginPosition);
                    buildCells.Add(buildableMultipleCells);
                }
            }
        }
        
        if(buildCells.Count <= 0) return;
        
        InstantiateAction(buildCells);    
    }

    private void InstantiateAction(List<BuildMultipleCells> buildCells)
    {
        foreach (var cell in buildCells)
        {
            cell.Cell.Slot.IsFull = true;
            Object.Instantiate(cell.BuildObject,cell.SpawnPosition,Quaternion.identity);
        }
    }
}

public interface IBuildable
{
    
}



public struct BuildMultipleCells
{
    public float CellSize;
    public Vector3 OriginPosition;
    public GameObject BuildObject;
        
    public Vector3 SpawnPosition;
    public Grid<Cell<GameObject>> Cell;
        
    public BuildMultipleCells(Grid<Cell<GameObject>> cell,GameObject gameObject, float cellSize, Vector3 originPosition)
    {
        CellSize = cellSize;
        OriginPosition = originPosition;
        Cell = cell;
        BuildObject = gameObject;
            
        SpawnPosition = new Vector3(cell.Slot.GridX,0, cell.Slot.GridZ) * CellSize + OriginPosition + new Vector3(CellSize / 2, 0, CellSize / 2);
    }
}