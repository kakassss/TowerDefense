using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class CellManager
{
    private Grid<Cell<GameObject>>[,] _grid;
    private int _width;
    private int _height;
    private float _cellSize;
    private Vector3 _originPosition;
    
    private Utils _utils;
    
    public Grid<Cell<GameObject>>[,] Grid => _grid;
    public int Width => _width;
    public int Height => _height;
    public float CellSize => _cellSize;
    public Vector3 OriginPosition => _originPosition;
    
    
    public CellManager(int width, int height,float cellSize, Vector3 originPosition,Utils utils)
    {
        _grid = new Grid<Cell<GameObject>>[width, height];
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _originPosition = originPosition;
        
        _utils = utils;
        
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                _grid[i, j] = new Grid<Cell<GameObject>>
                {
                    Slot = new Cell<GameObject>(false, CellPowerEnum.Normal)
                };
            }
        }
    }
    
    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * CellSize + _originPosition;
    }
    
    public void GetXZ(Vector3 worldPos, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPos -_originPosition).x/ _cellSize);
        z = Mathf.FloorToInt((worldPos- _originPosition).z/ _cellSize);
    }
    
    public bool CheckCellState(Vector3 worldPos)
    {
        var cell = GetCellAtIndex(worldPos);
        if (cell == null) return true;
        
        return cell.Slot.IsFull;
    }

    public void BuildGridEntity(Vector3 worldPos, GridEntitySO currentGridEntity, GameObject gameObject)
    {
        var mousePosCell = GetCellAtIndex(worldPos);
        
        if(mousePosCell == null) return;

        List<BuildCell> buildCells = new List<BuildCell>();

        GetXZ(worldPos,out var x, out var z);
        
        Debug.Log("X Z " + x + z);
        
        for (int i = 0; i < currentGridEntity.X; i++)
        {
            for (int j = 0; j < currentGridEntity.Z; j++)
            {
                if ( x + i >= 0 && z + j >= 0 && x < _width && z < _height)
                {
                    var buildCell = _grid[x + i, z + j];
                    if(buildCell.Slot.IsFull == true) return;
                
                    Debug.Log("buildCell " + (x+i) + " " + (z + j));
                
                    BuildCell buildableCell = new BuildCell(x + i, z + j, _cellSize, _originPosition,buildCell);
                    buildCell.Slot.Entity = gameObject;
                    buildCells.Add(buildableCell);
                }
            }
        }
        
        if(buildCells.Count <= 0) return;
        
        BuildAction(buildCells);    
    }

    private void BuildAction(List<BuildCell> buildCells)
    {
        foreach (var cell in buildCells)
        {
            cell.Cell.Slot.IsFull = true;
            Object.Instantiate(cell.Cell.Slot.Entity,cell.SpawnPosition,Quaternion.identity);
        }
        
    }

    public struct BuildCell
    {
        public int X;
        public int Z;
        public float CellSize;
        public Vector3 OriginPosition;
        
        public Vector3 SpawnPosition;
        public Grid<Cell<GameObject>> Cell;
        
        public BuildCell(int x, int z, float cellSize, Vector3 originPosition, Grid<Cell<GameObject>> cell)
        {
            X = x;
            Z = z;
            CellSize = cellSize;
            OriginPosition = originPosition;
            Cell = cell;
            
            SpawnPosition = new Vector3(X,0, Z) * CellSize + OriginPosition + new Vector3(CellSize / 2, 0, CellSize / 2);
        }

    }
    
    #region GetCellActions
    
    public Grid<Cell<GameObject>> GetCellAtIndex(Vector3 worldPos)
    {
        GetXZ(worldPos,out var x, out var z);
        if ( x >= 0 && z >= 0 && x < _width && z < _height)
        {
            return _grid[x, z];
        }
        
        return null;
    }
    
    private Vector3 GetCellPosition(Vector3 worldPos)
    {
        GetXZ(worldPos,out var x, out var z);
        return GetWorldPosition(x, z);
    }
    
    public Vector3 GetCellMidPointPosition(Vector3 worldPos)
    {
        GetXZ(worldPos,out var x, out var z);
        var cellPos = GetWorldPosition(x, z);
        return cellPos + new Vector3(CellSize / 2, 0, CellSize / 2);
    }
    
    #endregion
    
    #region SetCellActions

    public void SetCellAtIndex(Vector3 worldPos,GameObject gameObject)
    {
        var cell = GetCellAtIndex(worldPos);
        if(cell == null) return;
        
        SetCellFull(cell,gameObject);
    }
    
    public void SetCellFull(Grid<Cell<GameObject>> cell, GameObject gameObject)
    {
        cell.Slot.IsFull = true;
        cell.Slot.Entity = gameObject;
    }

    public void SetCellEmptyWithDestroy(Grid<Cell<GameObject>> cell,GameObject gameObject)
    {
        cell.Slot.IsFull = false;
        cell.Slot.Entity = null;
    }

    public void SetCellEmptyWithInput(Vector3 worldPos, GameObject gameObject)
    {
        var cell = GetCellAtIndex(worldPos);
        cell.Slot.IsFull = false;
        cell.Slot.Entity = null;
    }

    #endregion
    
    
}