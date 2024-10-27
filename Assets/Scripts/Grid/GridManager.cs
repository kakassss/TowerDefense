using System;
using Unity.VisualScripting;
using UnityEngine;

public class CellManager
{
    private Grid<Cell>[,] _grid;
    private int _width;
    private int _height;
    private float _cellSize;
    private Vector3 _originPosition;
    
    
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
                    Slot = new Cell(new Vector3(i,0,j),false)
                };
                
                Debug.Log(_grid[i,j].Slot.Position);
            }
        }
    }

    
    public Vector3 GetPositionWithVector(Vector3 position)
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (_grid[i, j].Slot.Position == position)
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
    
    public Vector3 GetPositionWithXY(int width,int height)
    {
        return _grid[width, height].Slot.Position;
    }
}