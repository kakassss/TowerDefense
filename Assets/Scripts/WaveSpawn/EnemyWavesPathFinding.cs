using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Profiling;
using Random = UnityEngine.Random;

public class EnemyWavesPathFinding
{
    public List<Vector3> SpawnPoints => _calculatedSpawnPoints;
    public Vector3 CalculatedSpawnPoint;
    
    private List<Column> _allColumnsPowerSize = new List<Column>();
    private List<Column> _columnsPowerSizeSorted = new List<Column>();
    private IOrderedEnumerable<Column> _shuffleList;
    
    private List<Vector3> _calculatedSpawnPoints = new List<Vector3>();
    private CellManager _cellManager;
    private CellPowerManager _cellPowerManager;
    
    private EnemyWavesPathFinding(CellManager cellManager, CellPowerManager cellPowerManager)
    {
        _cellManager = cellManager;
        _cellPowerManager = cellPowerManager;
    }
    
    private void ActiveCellWays(Vector3 spawnPointOffset)// to calculate enemy spawn position
    {
        _calculatedSpawnPoints.Clear();
        
        var activeColumns = _cellManager.GetActiveColumnsStruct();

        foreach (var activeColumn in activeColumns)
        {
            var cell = _cellManager.GetFrontCellAtActiveColumn(activeColumn.Index);
            Debug.Log("active column selected cell " + cell.Name);
            _calculatedSpawnPoints.Add(_cellManager.GetCellMidPointPositionXZ(cell.GridIndexX,cell.GridIndexZ) + spawnPointOffset);
        }
    }
    
    #region OldPathFinding
    //private Dictionary<int, float> _allColumnsPowerSizeDic = new Dictionary<int, float>();
    
    // private Vector3 GetColumnSpawnPoint(int columnIndex)
    // {
    //     var currentCell = _cellManager.GetFrontCellAtActiveColumn(columnIndex);
    //     return _cellManager.GetCellMidPointPositionXZ(currentCell.GridIndexX,currentCell.GridIndexZ);
    // }
    //
    // public Vector3 GetCalculatedPowerSizeSpawnPoints(Vector3 spawnPointOffset)
    // {
    //     _allColumnsPowerSizeDic.Clear();
    //     
    //     _allColumnsPowerSizeDic = _cellPowerManager.GetAllColumnsPowerSize();
    //     IOrderedEnumerable<KeyValuePair<int, float>> keyValuePairs;
    //     keyValuePairs = _allColumnsPowerSizeDic.OrderBy(powerSize => powerSize.Value);
    //     
    //     if (_allColumnsPowerSizeDic.Count == 1)
    //     {
    //         List<int> keyList = new List<int>(_allColumnsPowerSizeDic.Keys);
    //         return CalculatedSpawnPoint = GetColumnSpawnPoint(keyList[0]) + spawnPointOffset;
    //     }
    //     
    //     CalculatedSpawnPoint = CalculateSpawnPoint(keyValuePairs, spawnPointOffset);
    //     
    //     if (CalculatedSpawnPoint == Vector3.zero)
    //     {
    //         CalculatedSpawnPoint = GetCalculatedPowerSizeSpawnPoints(spawnPointOffset);
    //     }
    //     // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //     // cube.transform.localScale = new Vector3(5f,3.5f,0.5f);
    //     // cube.transform.position = CalculatedSpawnPoint;
    //         
    //     //Debug.LogError("Couldn't calculate power spawn points");
    //     return CalculatedSpawnPoint;
    // }
    //
    // private Vector3 CalculateSpawnPoint(IOrderedEnumerable<KeyValuePair<int, float>> keyValuePairs, Vector3 spawnPointOffset)
    // {
    //     var random = Random.Range(0, 100);
    //     
    //     //TODO SORUN ŞU
    //     //4 tane aynı ratede column gelirse hep ilk olan seçiliyor
    //     //shuffle tarzı bi şey deneyebilirsin, fakat, bu eğer 3 tane aynı 1 tane farklı gibi olan durumları
    //     //nasıl etkiler tam bilemiyorsun
    //     //bu guid new guid shuffle yapıyor, fakat bi tık korkuttu, yani stackover flowda çöker cart curt denmiş
    //     //https://stackoverflow.com/questions/273313/randomize-a-listt
    //     //performans sıkıntısı yaratıyormus
    //     keyValuePairs = keyValuePairs.OrderBy(_ => Guid.NewGuid());
    //     foreach (var column in keyValuePairs)
    //     {
    //         if (random <= column.Value)// column value is spawn rate
    //         {
    //             Debug.Log("onur ran " + random + " "  + column.Value);
    //             return GetColumnSpawnPoint(column.Key) + spawnPointOffset;
    //         }
    //     }
    //     return Vector3.zero;
    // }
    #endregion
    
    private Vector3 GetColumnSpawnPoint(int columnIndex)
    {
        var currentCell = _cellManager.GetFrontCellAtActiveColumn(columnIndex);
        return _cellManager.GetCellMidPointPositionXZ(currentCell.GridIndexX,currentCell.GridIndexZ);
    }
    
    public Vector3 GetCalculatedPowerSizeSpawnPoints(Vector3 spawnPointOffset)
    {
        _allColumnsPowerSize.Clear();
        _columnsPowerSizeSorted.Clear();

        _allColumnsPowerSize = _cellPowerManager.GetAllColumnsPowerSize();
        _columnsPowerSizeSorted = _allColumnsPowerSize.OrderByDescending(c => c.ColumnTotalPower).ToList();
        
        if (_allColumnsPowerSize.Count == 1)
        {
            return CalculatedSpawnPoint = GetColumnSpawnPoint(_allColumnsPowerSize[0].Index) + spawnPointOffset;
        }
        
        CalculatedSpawnPoint = CalculateSpawnPoint(_columnsPowerSizeSorted, spawnPointOffset);
        
        if (CalculatedSpawnPoint == Vector3.zero)
        {
            CalculatedSpawnPoint = GetCalculatedPowerSizeSpawnPoints(spawnPointOffset);
        }

        return CalculatedSpawnPoint;
    }

    private Vector3 CalculateSpawnPoint(List<Column> columnList, Vector3 spawnPointOffset)
    {
        //Profiler.BeginSample("SpawnPoint");
        var random = Random.Range(0, 100);
        
        System.Random random2 = new System.Random();
        _shuffleList = columnList.OrderBy(c => random2.Next());
        foreach (var column in _shuffleList)
        {
            if (random <= column.ColumnTotalPower)// column value is spawn rate
            {
                return GetColumnSpawnPoint(column.Index) + spawnPointOffset;
            }
        }
        //Profiler.EndSample();
        return Vector3.zero;
    }
}





