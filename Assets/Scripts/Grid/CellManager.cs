using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public struct Column
{
    public int Index;
    public int ColumnTotalPower;

    public Column(int index, int columnTotalPower)
    {
        Index = index;
        ColumnTotalPower = columnTotalPower;
    }
    
}

public class CellManager
{
    #region PrivateVariables
    
    private Grid<Cell>[,] _grid;
    private int _width;
    private int _height;
    private float _cellSize;
    private Vector3 _originPosition;
    private GridSOData _gridSOData;
    #endregion
    
    private Utils _utils;
    private List<Column> _activeColumns = new List<Column>();

    #region Properties
    public Grid<Cell>[,] Grid => _grid;
    public int Width => _width; // 8
    public int Height => _height; // 8
    public float CellSize => _cellSize; // 4
    public Vector3 OriginPosition => _originPosition; // -20, 0, -15.7
    #endregion
    
    private int randomer;
    #region Constructer
    public CellManager(GridSOData gridSOData)
    {
        _gridSOData = gridSOData;
        
        _grid = new Grid<Cell>[_gridSOData.Width, _gridSOData.Height];
        _width = _gridSOData.Width;
        _height = _gridSOData.Height;
        _cellSize = _gridSOData.CellSize;
        _originPosition = _gridSOData.OriginPosition;
        
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                _grid[i, j] = new Grid<Cell>
                {
                    Slot = new Cell(i,j, _gridSOData.GetCells[j * _width + i], ElementType.Normal)
                };
            }
        }
        
        //GridIndexX -> Row
        //GridIndexZ -> Column
        
        //Grid[0,X] => will give column index
        //Grid[X,0] => will give row index
        
        // for (int i = 0; i < _grid.GetLength(0); i++)
        // {
        //     Debug.Log(_grid[0,i].Slot  + " Current grid column " + _grid[0,i].Slot.Column);
        //     Debug.Log(_grid[0,i].Slot.Name);
        // }
    }

    #endregion
    
    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * _cellSize + _originPosition;
    }
    
    public void GetXZ(Vector3 worldPos, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPos - _originPosition).x / _cellSize);
        z = Mathf.FloorToInt((worldPos - _originPosition).z / _cellSize);
    }
    
    public (int X,int Z) GetXZ(Vector3 worldPos)
    {
        return (Mathf.FloorToInt((worldPos - _originPosition).x / _cellSize), 
            Mathf.FloorToInt((worldPos - _originPosition).z / _cellSize));
    }
    
    public bool CheckCellState(Vector3 worldPos)
    {
        var cell = GetCellAtIndex(worldPos);
        if (cell == null) return true;
        
        return cell.Slot.IsEntityActive || cell.Slot.IsFull;
    }
    
    public List<Column> GetActiveColumnsStruct()
    {
        _activeColumns.Clear();
        
        // Iterate through columns first (j)
        for (int j = 0; j < _grid.GetLength(1); j++) 
        {
            // Then check each row in that column (i)
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                if (_grid[i, j].Slot.IsEntityActive)
                {
                    _activeColumns.Add(new Column(j, 0));
                    break; // Exit inner loop once we find a full cell
                }
            }
        }
        
        return _activeColumns;
    }
    
    //Use after GetActiveColumns function
    //These functions are just giving active column, not indivual cell
    public Cell GetRandomCellAtActiveColumn(int columnIndex) 
    {
        if(_activeColumns.Count <= 0) return null;
        return _grid[Random.Range(0,Width), columnIndex].Slot;
    }
    
    //Get mid cell at grid
    public Cell GetDefaultCellAtActiveColumn()// Only works with odd numbers,
    {
        return _grid[Height-1, Mathf.FloorToInt(Width/2)].Slot;
    }
    
    //Find the front cell at selected column
    public Cell GetFrontCellAtActiveColumn(int columnIndex)
    {
        if(_activeColumns.Count <= 0) return null;
        return _grid[Height-1, columnIndex].Slot;
    }
    
    #region GetCellActions
    
    public Grid<Cell> GetCellAtIndex(Vector3 worldPos)
    {
        GetXZ(worldPos,out var x, out var z);
        if ( x >= 0 && z >= 0 && x < Width && z < Height)
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

    public Vector3 GetMidCellPosition()
    {
        var midGrid = _grid[_width / 2, _height / 2];
        return GetWorldPosition(midGrid.Slot.GridIndexX, midGrid.Slot.GridIndexZ);
    }
    
    #endregion
    
    #region SetCellActions

    public void SetCellAtIndex(Vector3 worldPos,BaseTower baseTower)
    {
        var cell = GetCellAtIndex(worldPos);
        if(cell == null) return;
        
        SetCellFull(cell,baseTower);
    }
    
    public void SetCellFull(Grid<Cell> cell, BaseTower baseTower)
    {
        cell.Slot.IsFull = true;
        cell.Slot.IsEntityActive = true;
        cell.Slot.Entity = baseTower;
    }

    public void SetCellEmptyWithDestroy(Grid<Cell> cell)
    {
        cell.Slot.IsFull = false;
        cell.Slot.IsEntityActive = false;
        cell.Slot.Entity = null;
    }

    public void SetCellEmptyWithInput(Vector3 worldPos)
    {
        var cell = GetCellAtIndex(worldPos);
        cell.Slot.IsFull = false;
        cell.Slot.IsEntityActive = false;
        cell.Slot.Entity = null;
    }

    #endregion
    
    
}