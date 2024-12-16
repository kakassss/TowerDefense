using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyWavesPathFinding
{
    public List<Vector3> SpawnPoints => _calculatedSpawnPoints;
    public Vector3 CalculatedSpawnPoint;
    
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
        
        var activeColumns = _cellManager.GetActiveColumns();

        foreach (var activeColumn in activeColumns)
        {
            var cell = _cellManager.GetFrontCellAtActiveColumn(activeColumn);
            Debug.Log("active column selected cell " + cell.Name);
            _calculatedSpawnPoints.Add(_cellManager.GetCellMidPointPositionXZ(cell.GridIndexX,cell.GridIndexZ) + spawnPointOffset);
        }
    }

    private Vector3 GetColumnSpawnPoint(int columnIndex)
    {
        var currentCell = _cellManager.GetFrontCellAtActiveColumn(columnIndex);
        return _cellManager.GetCellMidPointPositionXZ(currentCell.GridIndexX,currentCell.GridIndexZ);
    }

    public Vector3 GetCalculatedPowerSizeSpawnPoints(Vector3 spawnPointOffset)
    {
        var dic = _cellPowerManager.GetAllColumnsPowerSize();
        var keyValuePairs = dic.OrderBy(powerSize => powerSize.Value);

        if (dic.Count == 1)
        {
            List<int> keyList = new List<int>(dic.Keys);
            return CalculatedSpawnPoint = GetColumnSpawnPoint(keyList[0]) + spawnPointOffset;
        }
        var random = Random.Range(0, 100);

        foreach (var column in keyValuePairs)
        {
            if (random <= column.Value)
            {
                //Debug.Log("random " + random +"column hase choosen " + column.Key);
                return CalculatedSpawnPoint = GetColumnSpawnPoint(column.Key) + spawnPointOffset;
            }
        }

        Debug.LogError("Couldn't calculate power spawn points");
        return Vector3.zero;
    }
}