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
                    Slot = new Cell<GameObject>(i,j,false, CellPowerEnum.Normal)
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