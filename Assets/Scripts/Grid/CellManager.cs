using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
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
    #endregion
    
    private Utils _utils;
    private List<Column> _activeColumns = new List<Column>();

    #region Properties
    public Grid<Cell>[,] Grid => _grid;
    public int Width => _width;
    public int Height => _height;
    public float CellSize => _cellSize;
    public Vector3 OriginPosition => _originPosition;
    #endregion
    
    private IInstantiator _instantiator;
    private int randomer;
    #region Constructer
    public CellManager(int width, int height,float cellSize, Vector3 originPosition, GameObject gridPrefab, IInstantiator instantiator, Transform parent)
    {
        _grid = new Grid<Cell>[width, height];
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _originPosition = originPosition;
        _instantiator = instantiator;
        
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                _grid[i, j] = new Grid<Cell>
                {
                    Slot = new Cell(i,j,false, ElementType.Normal)
                };
                    
                var text =  _instantiator.InstantiatePrefab(gridPrefab, GetWorldPosition(i, j), Quaternion.identity, parent);
                text.transform.position += new Vector3(cellSize/2, 0.15f, cellSize/2);
                text.GetComponentInChildren<TextMeshProUGUI>().text = i + "," + j;
                if (randomer == 0)
                {
                    randomer = 1;
                    text.GetComponentInChildren<Image>().color = Color.blue;
                    continue;
                }
                
                if (randomer == 1)
                {
                    text.GetComponentInChildren<Image>().color = Color.green;
                    randomer = 0;
                    continue;
                }
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
    // public CellManager(int width, int height,float cellSize, Vector3 originPosition,Utils utils)
    // {
    //     _grid = new Grid<Cell>[width, height];
    //     _width = width;
    //     _height = height;
    //     _cellSize = cellSize;
    //     _originPosition = originPosition;
    //     
    //     _utils = utils;
    //     
    //     for (int i = 0; i < _grid.GetLength(0); i++)
    //     {
    //         for (int j = 0; j < _grid.GetLength(1); j++)
    //         {
    //             _grid[i, j] = new Grid<Cell>
    //             {
    //                 Slot = new Cell(i,j,false, ElementType.Normal)
    //             };
    //         }
    //     }
    //     
    //     // for (int i = 0; i < _grid.GetLength(0); i++)
    //     // {
    //     //     for (int j = 0; j < _grid.GetLength(1); j++)
    //     //     {
    //     //         Debug.Log(_grid[i,j].Slot  + " Current grid column " + _grid[i,j].Slot.Column);
    //     //     }
    //     // }
    // }
    #endregion
    
    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * CellSize + _originPosition;
    }
    
    public void GetXZ(Vector3 worldPos, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPos -_originPosition).x/ _cellSize);
        z = Mathf.FloorToInt((worldPos- _originPosition).z/ _cellSize);
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
        
        return cell.Slot.IsFull;
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
                if (_grid[i, j].Slot.IsFull)
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

    public void SetCellAtIndex(Vector3 worldPos,BaseTower baseTower)
    {
        var cell = GetCellAtIndex(worldPos);
        if(cell == null) return;
        
        SetCellFull(cell,baseTower);
    }
    
    public void SetCellFull(Grid<Cell> cell, BaseTower baseTower)
    {
        cell.Slot.IsFull = true;
        cell.Slot.Entity = baseTower;
    }

    public void SetCellEmptyWithDestroy(Grid<Cell> cell)
    {
        cell.Slot.IsFull = false;
        cell.Slot.Entity = null;
    }

    public void SetCellEmptyWithInput(Vector3 worldPos)
    {
        var cell = GetCellAtIndex(worldPos);
        cell.Slot.IsFull = false;
        cell.Slot.Entity = null;
    }

    #endregion
    
    
}