using System.Collections.Generic;
using UnityEngine;

public class CellPowerManager
{
    private List<Column> _activedColumnPowerRate = new List<Column>();
    private List<Column> _activedColumnsPowerSize = new List<Column>();
    
    private List<Cell> _selectedColumnPower = new List<Cell>();
    
    private CellManager _cellManager;

    private float _tempPower;
    private float _totalPower;
    
    public CellPowerManager(CellManager cellManager)
    {
        _cellManager = cellManager;
    }
    
    //Get Selected ColumnPowerSize
    public float GetSelectedColumnPowerSize(int columnIndex)
    {
        _selectedColumnPower.Clear();
        _tempPower = 0;
        
        for (int i = 0; i < _cellManager.Width; i++)
        {
            _selectedColumnPower.Add(_cellManager.Grid[i,columnIndex].Slot);
        }

        for (int i = 0; i < _selectedColumnPower.Count; i++)
        {
            _tempPower += _cellManager.Grid[0, columnIndex].Slot.Power;
        }
        
        return _tempPower;
    }
    
   

    #region OldPowerSizeFunc
    //private Dictionary<int, float> _columnPowerRate = new Dictionary<int, float>();
    //private Dictionary<int, float> _powerSizeDic = new Dictionary<int, float>();
    // public Dictionary<int, float> GetAllColumnsPowerSize()
    // {
    //     if(_cellManager.GetActiveColumns().Count <= 0) return null;
    //     
    //     var activeColumns = _cellManager.GetActiveColumns();
    //     var activeColumnsCount = activeColumns.Count;
    //
    //     if (activeColumnsCount == 1)
    //     {
    //         _powerSizeDic.Add(_cellManager.GetActiveColumns()[0], 0);
    //         return _powerSizeDic;
    //     }
    //
    //     // for (int i = 0; i < activeColumnsCount; i++)
    //     // {
    //     //     Debug.Log("active columnss " + activeColumns[i]);
    //     // }
    //     
    //     _columnPowerRate.Clear();
    //     _powerSizeDic.Clear();
    //     _totalPower = 0;
    //     
    //     
    //     //Debug.Log("activeColumnsCount " + activeColumnsCount);
    //     int index = 0;
    //     foreach (var column in activeColumns)
    //     {
    //         _tempPower = 0;
    //         
    //         // We don't check just only active cell, looking every one of them, if its empty then powerRate will be 0
    //         for (int j = 0; j < _cellManager.Height; j++)
    //         {
    //             var cell = _cellManager.Grid[j, column];
    //             //Debug.Log("current " + j + " "+ cell.Slot.Power);
    //             GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //             cube.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
    //             cube.transform.position =
    //                 _cellManager.GetCellMidPointPositionXZ(cell.Slot.GridIndexX, cell.Slot.GridIndexZ);
    //             
    //             _tempPower += cell.Slot.Power;
    //             _totalPower += cell.Slot.Power;
    //         }
    //         //Debug.Log("current cell " + _tempPower);
    //         _powerSizeDic.Add(column, _tempPower);
    //         index++;
    //     }
    //     //
    //     // for (int i = 0; i < activeColumnsCount; i++)
    //     // {
    //     //     _tempPower = 0;
    //     //     
    //     //     // We don't check just only active cell, looking every one of them, if its empty then powerRate will be 0
    //     //     for (int j = 0; j < _cellManager.Height; j++)
    //     //     {
    //     //         var cell = _cellManager.Grid[j, i];
    //     //         Debug.Log("current i " + i + cell.Slot.Power);
    //     //         GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //     //         cube.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
    //     //         cube.transform.position =
    //     //             _cellManager.GetCellMidPointPositionXZ(cell.Slot.GridIndexX, cell.Slot.GridIndexZ);
    //     //         
    //     //         _tempPower += cell.Slot.Power;
    //     //         _totalPower += cell.Slot.Power;
    //     //     }
    //     //     Debug.Log("current cell " + _tempPower);
    //     //     _powerSizeDic.Add(i, _tempPower);
    //     // }
    //
    //     //Calculate powerRate for each colomn
    //     foreach (var power in _powerSizeDic)
    //     {
    //         float powerRate = Mathf.CeilToInt(_totalPower/ power.Value) * 10;
    //         _columnPowerRate.Add(power.Key, powerRate);
    //     }
    //     // for (int i = 0; i < _powerSizeDic.Count; i++)
    //     // {
    //     //     float powerRate = Mathf.CeilToInt(_totalPower/ _powerSizeDic[i]) * 10;
    //     //    
    //     //     //Debug.Log(i  + " power rate: " + powerRate);
    //     //     _columnPowerRate.Add(_powerSizeDic.Keys[i], powerRate);
    //     // }
    //
    //     return _columnPowerRate;
    //     //Debug.Log("total power " + _totalPower);
    // }

    #endregion
    
    //Creating powerSize for each column
    //1.Step
    //Find every columnPowerSize
    //Find total Power Size
    //Add each one column to (int,float) dictionary 
    //2.Step
    //Find each one column power rate
    //Add to list
        
    //PowerSize[0] -> 0, 40
    //PowerSize[1] -> 1, 80
    //PowerSize[2] -> 2, 20

    public List<Column> GetAllColumnsPowerSize()
    {
        var activeColumns = _cellManager.GetActiveColumnsStruct();
        var activeColumnsCount = activeColumns.Count;
       
        if(activeColumnsCount <= 0) return null;
        
        if (activeColumnsCount == 1)
        {
            _activedColumnPowerRate.Add(activeColumns[0]);
            return _activedColumnPowerRate;
        }
        
        _activedColumnsPowerSize.Clear();
        _activedColumnPowerRate.Clear();
        _totalPower = 0;
        
        foreach (var column in activeColumns)
        {
            _tempPower = 0;
            
            // We don't check just only active cell, looking every one of them, if its empty then powerRate will be 0
            for (int j = 0; j < _cellManager.Height; j++)
            {
                var cell = _cellManager.Grid[j, column.Index];
                //Debug.Log("current " + j + " "+ cell.Slot.Power);
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                cube.transform.position =
                    _cellManager.GetCellMidPointPositionXZ(cell.Slot.GridIndexX, cell.Slot.GridIndexZ);
                
                _tempPower += cell.Slot.Power;
                _totalPower += cell.Slot.Power;
            }
            _activedColumnsPowerSize.Add(new Column(column.Index, (int)_tempPower));
        }
    
        //Calculate powerRate for each colomn
        foreach (var power in _activedColumnsPowerSize)
        {
            float powerRate = Mathf.CeilToInt(_totalPower/ power.ColumnTotalPower) * 10;
            _activedColumnPowerRate.Add(new Column(power.Index, (int)powerRate));
        }
        
        return _activedColumnPowerRate;
    }

}