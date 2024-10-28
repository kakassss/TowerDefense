using System;
using UnityEngine;

public class CellManager
{
    private Grid<Cell>[,] _grid;
    private int _width;
    private int _height;
    private float _cellSize;
    private Vector3 _originPosition;


    private Utils _utils;
    
    
    public Grid<Cell>[,] Grid => _grid;
    public int Width => _width;
    public int Height => _height;
    public float CellSize => _cellSize;
    public Vector3 OriginPosition => _originPosition;
    
    
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
                    Slot = new Cell(new Vector3(i,0,j) ,false)
                };
                
                Debug.Log(_grid[i,j].Slot.Position);
            }
        }
    }


    public Vector3 GetPositionMidpointAtGridIndex(Vector3 position)
    {
        var truncatePosition = GetPositionTruncatePosition(position);

        var midPointX = truncatePosition.x / 2;
        var midPointZ = truncatePosition.z / 2;

        return new Vector3(midPointX, 0, midPointZ);
    }
    
    
    public Vector3 GetPositionTruncatePosition(Vector3 position)
    {
        var intPosX = (int)Math.Truncate(position.x);
        var intPosZ = (int)Math.Truncate(position.z);
        var floorVector = new Vector3(intPosX, 0, intPosZ);
        
        Debug.Log("midPoint spawn pos " + floorVector);
        
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (_grid[i, j].Slot.Position == floorVector)
                {
                    return _grid[i, j].Slot.Position;
                }
            }
        }
        
        throw new InvalidOperationException("Position not found in the grid.");
    }
    

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * CellSize + _originPosition;
    }
    
    public Vector3 GetPositionWithXZ(int width,int height)
    {
        return _grid[width, height].Slot.Position;
    }
    
    public void GetXZ(Vector3 worldPos, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPos -_originPosition).x/ _cellSize);
        z = Mathf.FloorToInt((worldPos- _originPosition).z/ _cellSize);
    }

    public Vector3 GetCellMidPointPosition(Vector3 worldPos)
    {
        GetXZ(worldPos,out var x, out var z);
        var cellPos = GetWorldPosition(x, z);
        return cellPos + new Vector3(CellSize / 2, 0, CellSize / 2);
    }
    
    public Grid<Cell> GetCellAtIndex(Vector3 worldPos)
    {
        GetXZ(worldPos,out var x, out var z);
        
        if ( x >= 0 && z >= 0 && x < _width && z < _height)
        {
            return _grid[x, z];
        }
        
        throw new InvalidOperationException("Position not found in the grid.");
    }

    public void SetCellState(Vector3 worldPos,bool state)
    {
        var cell = GetCellAtIndex(worldPos);
        cell.Slot.IsFull = state;
    }
    
    public bool CheckCellState(Vector3 worldPos)
    {
        return GetCellAtIndex(worldPos).Slot.IsFull;
    }

    private Vector3 GetCellPosition(Vector3 worldPos)
    {
        GetXZ(worldPos,out var x, out var z);
        return GetWorldPosition(x, z);
    }
}