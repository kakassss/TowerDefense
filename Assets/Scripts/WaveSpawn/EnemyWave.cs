using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

[Serializable]

public class WaveData
{
    public int EnemyID;
    public int count;
    public float Rate;
}

public class EnemyWave : MonoBehaviour
{
    [InfoBox("Enemy ID -> Goblin -> 1 " + " Troll -> 0")]
    public bool canGizmos = false;
    
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<WaveData> _waveData;
    [SerializeField] private Vector3 _spawnPointOffset;
    
    private List<Vector3> _calculatedSpawnPoints = new List<Vector3>();
    
    private EnemyPool _enemyPool;
    private CellManager _cellManager;
    
    [Inject]
    private void Construct(EnemyPool enemyPool, CellManager cellManager)
    {
        _enemyPool = enemyPool;
        _cellManager = cellManager;
    }

    private Cell _defaultOpenCell;
    private DrawCubeGizmos _defaultCellGizmos;
    private void Start()
    {
        _defaultOpenCell = _cellManager.GetDefaultCellAtActiveColumn();
        _defaultCellGizmos = new DrawCubeGizmos(_cellManager.GetCellMidPointPositionXZ(_defaultOpenCell.GridIndexX, _defaultOpenCell.GridIndexZ));
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
    
    private void ActiveCellWays()// to calculate enemy spawn position
    {
        _calculatedSpawnPoints.Clear();
        
        var activeColumns = _cellManager.GetActiveColumns();

        foreach (var activeColumn in activeColumns)
        {
            var cell = _cellManager.GetFrontCellAtActiveColumn(activeColumn);
            Debug.Log("active column selected cell " + cell.Name);
            _calculatedSpawnPoints.Add(_cellManager.GetCellMidPointPositionXZ(cell.GridIndexX,cell.GridIndexZ) + _spawnPointOffset);
        }
    }

    private void OnDrawGizmos()
    {
        _defaultCellGizmos?.DrawGizmos(Color.yellow); // default open cell gizmos
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