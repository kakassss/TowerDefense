using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;

[Serializable]
public class WaveData
{
    public int EnemyID;
    public int count;
    public float Rate;
}

public class EnemyWave : MonoBehaviour
{
    public bool canGizmos = false;
    
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<WaveData> _waveData;
    
    private EnemyPool _enemyPool;

    private CellManager _cellManager;
    
    [Inject]
    private void Construct(EnemyPool enemyPool, CellManager cellManager)
    {
        _enemyPool = enemyPool;
        _cellManager = cellManager;
    }

    private void Start()
    {
        //SpawnWaveAsync().Forget();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActiveCellWays();
            canGizmos = true;
        }
    }

    private List<Vector3> _calculatedSpawnPoints = new List<Vector3>();
    
    private void ActiveCellWays()// to calculate enemy spawn position
    {
        _calculatedSpawnPoints.Clear();
        
        var activeColumns = _cellManager.GetActiveColumns();

        foreach (var activeColumn in activeColumns)
        {
            var cell = _cellManager.GetRandomCellAtActiveColumn(activeColumn);
            Debug.Log("active column selected cell " + cell.Name);
            _calculatedSpawnPoints.Add(_cellManager.GetCellMidPointPositionXZ(cell.GridIndexX,cell.GridIndexZ));
        }
    }

    private void OnDrawGizmos()
    {
        if(canGizmos == false) return;
        if(_calculatedSpawnPoints.Count == 0) return;
        Gizmos.color = Color.green;
        for (int i = 0; i < _calculatedSpawnPoints.Count; i++)
        {
            Gizmos.DrawCube(_calculatedSpawnPoints[i],new Vector3(1f,1f,1f));
        }
    }

    private async UniTaskVoid SpawnWaveAsync()
    {
        var waitTime = _waveData[0].Rate;
        
        for (int i = 0; i < _waveData.Count; i++)
        {
            for (int j = 0; j < _waveData[i].count; j++)
            {
                _enemyPool.GetObjectFromPool(_waveData[i].EnemyID, _spawnPoints[i].position);
                await UniTask.WaitForSeconds(waitTime);
            }
            await UniTask.WaitForSeconds(_waveData[i].Rate);
        }
    }
    
}
