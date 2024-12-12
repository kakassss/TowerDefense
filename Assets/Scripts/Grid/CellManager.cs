﻿using System.Collections.Generic;
using UnityEngine;

public class CellManager
{
    private Grid<Cell>[,] _grid;
    private int _width;
    private int _height;
    private float _cellSize;
    private Vector3 _originPosition;
    
    private Utils _utils;

    private List<Cell> _activeCells = new List<Cell>();
    private List<int> _activeColumns = new List<int>();
    
    public Grid<Cell>[,] Grid => _grid;
    public int Width => _width;
    public int Height => _height;
    public float CellSize => _cellSize;
    public Vector3 OriginPosition => _originPosition;
    
    public CellManager(int width, int height,float cellSize, Vector3 originPosition)
    {
        _grid = new Grid<Cell>[width, height];
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _originPosition = originPosition;
        
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                _grid[i, j] = new Grid<Cell>
                {
                    Slot = new Cell(i,j,j,i,false, CellPower.Normal)
                };
            }
        }
        
        //Grid[0,X] => will give column index
        //Grid[X,0] => will give row index
        
        // for (int i = 0; i < _grid.GetLength(0); i++)
        // {
        //     Debug.Log(_grid[0,i].Slot  + " Current grid column " + _grid[0,i].Slot.Column);
        //     Debug.Log(_grid[0,i].Slot.Name);
        // }
    }
    public CellManager(int width, int height,float cellSize, Vector3 originPosition,Utils utils)
    {
        _grid = new Grid<Cell>[width, height];
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _originPosition = originPosition;
        
        _utils = utils;
        
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                _grid[i, j] = new Grid<Cell>
                {
                    Slot = new Cell(i,j,i,j,false, CellPower.Normal)
                };
            }
        }

        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                Debug.Log(_grid[i,j].Slot  + " Current grid column " + _grid[i,j].Slot.Column);
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
    
    public List<int> GetActiveColumns()
    {
        _activeColumns.Clear();

        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                if (_grid[i, j].Slot.IsFull)
                {
                    if(_activeColumns.Contains(j)) continue;
                    _activeColumns.Add(j);
                    //break; // break current inner loop and allows the outer loop to proceed to next iteration
                }   
            }
        }
        return _activeColumns;
    }
    
    //Use after GetActiveColumns function
    public Cell GetRandomCellAtActiveColumn(int columnIndex)
    {
        if(_activeColumns.Count <= 0) return null;
        return _grid[Random.Range(0,Width), columnIndex].Slot;
    }
    
    public Cell GetDefaultCellAtActiveColumn()// Only works with odd numbers,
    {
        return _grid[Height-1, Mathf.FloorToInt(Width/2)].Slot;
    }
    
    public Cell GetFrontCellAtActiveColumn(int columnIndex)
    {
        if(_activeColumns.Count <= 0) return null;
        return _grid[Height-1, columnIndex].Slot;
    }
    
    #region GetCellActions
    
    public Grid<Cell> GetCellAtIndex(Vector3 worldPos)
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

    public Vector3 GetCellMidPointPositionXZ(int x, int z)
    {
        return new Vector3(x,0, z) * CellSize + OriginPosition + new Vector3(CellSize / 2, 0, CellSize / 2);
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
    
    public void SetCellFull(Grid<Cell> cell, GameObject gameObject)
    {
        cell.Slot.IsFull = true;
        cell.Slot.Entity = gameObject;
    }

    public void SetCellEmptyWithDestroy(Grid<Cell> cell,GameObject gameObject)
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