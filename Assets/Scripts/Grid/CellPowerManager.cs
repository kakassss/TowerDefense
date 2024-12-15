using System.Collections.Generic;
using UnityEngine;

public class CellPowerManager
{
    private Dictionary<int, float> _columnPowerRate = new Dictionary<int, float>();
    private Dictionary<int, float> _powerSizeDic = new Dictionary<int, float>();

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
    //Creating powerSize for each column
    public Dictionary<int, float> GetAllColumnsPowerSize()
    {
        if(_cellManager.GetActiveColumns().Count <= 0) return null;
        
        _columnPowerRate.Clear();
        _powerSizeDic.Clear();
        _totalPower = 0;
        
        var activeColumnsCount = _cellManager.GetActiveColumns().Count;

        if (activeColumnsCount == 1)
        {
            _powerSizeDic.Add(_cellManager.GetActiveColumns()[0], 0);
            return _powerSizeDic;
        }
        
        for (int i = 0; i < activeColumnsCount; i++)
        {
            _tempPower = 0;
            
            for (int j = 0; j < _cellManager.Width; j++)
            {
                var cell = _cellManager.Grid[j, i];
                _tempPower += cell.Slot.Power;
                _totalPower += cell.Slot.Power;
            }
            _powerSizeDic.Add(i, _tempPower);
        }

        
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
        Debug.Log("total power " + _totalPower);
        for (int i = 0; i < _powerSizeDic.Count; i++)
        {
           var powerRate = Mathf.CeilToInt(_totalPower/ _powerSizeDic[i]) * 10;
           
           Debug.Log(i  + " power rate: " + powerRate);
           _columnPowerRate.Add(i, powerRate);
        }

        return _columnPowerRate;
    }
    

}