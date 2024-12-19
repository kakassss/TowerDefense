using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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

    private Dictionary<int, float> dic = new Dictionary<int, float>();
    public Vector3 GetCalculatedPowerSizeSpawnPoints(Vector3 spawnPointOffset)
    {
        dic.Clear();
        
        dic = _cellPowerManager.GetAllColumnsPowerSize();
        IOrderedEnumerable<KeyValuePair<int, float>> keyValuePairs;
        keyValuePairs = dic.OrderBy(powerSize => powerSize.Value);
        
        if (dic.Count == 1)
        {
            List<int> keyList = new List<int>(dic.Keys);
            return CalculatedSpawnPoint = GetColumnSpawnPoint(keyList[0]) + spawnPointOffset;
        }
        
        CalculatedSpawnPoint = CalculateSpawnPoint(keyValuePairs, spawnPointOffset);
        
        if (CalculatedSpawnPoint == Vector3.zero)
        {
            CalculatedSpawnPoint = GetCalculatedPowerSizeSpawnPoints(spawnPointOffset);
        }
        // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // cube.transform.localScale = new Vector3(5f,3.5f,0.5f);
        // cube.transform.position = CalculatedSpawnPoint;
            
        //Debug.LogError("Couldn't calculate power spawn points");
        return CalculatedSpawnPoint;
    }

    private Vector3 CalculateSpawnPoint(IOrderedEnumerable<KeyValuePair<int, float>> keyValuePairs, Vector3 spawnPointOffset)
    {
        var random = Random.Range(0, 100);
        
        //TODO SORUN ŞU
        //4 tane aynı ratede column gelirse hep ilk olan seçiliyor
        //shuffle tarzı bi şey deneyebilirsin, fakat, bu eğer 3 tane aynı 1 tane farklı gibi olan durumları
        //nasıl etkiler tam bilemiyorsun
        //bu guid new guid shuffle yapıyor, fakat bi tık korkuttu, yani stackover flowda çöker cart curt denmiş
        //https://stackoverflow.com/questions/273313/randomize-a-listt
        //performans sıkıntısı yaratıyormus
        keyValuePairs = keyValuePairs.OrderBy(_ => Guid.NewGuid());
        foreach (var column in keyValuePairs)
        {
            if (random <= column.Value)// column value is spawn rate
            {
                Debug.Log("onur ran " + random + " "  + column.Value);
                return GetColumnSpawnPoint(column.Key) + spawnPointOffset;
            }
        }
        return Vector3.zero;
    }
    private void ShuffleList<T>(List<T> list)
    {
        System.Random random = new System.Random();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = random.Next(0, i + 1);

            var temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    
}





