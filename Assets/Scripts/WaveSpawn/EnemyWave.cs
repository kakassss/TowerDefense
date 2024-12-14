using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;



public class EnemyWave : MonoBehaviour
{
    [InfoBox("Enemy ID")]
    [InfoBox("Troll -> 0")]
    [InfoBox("Goblin -> 1")]
    
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<WaveDataContainer> _totalWaveData;
    [SerializeField] private Vector3 _spawnPointOffset;
    
    private List<Vector3> _calculatedSpawnPoints = new List<Vector3>();
    
    private EnemyPool _enemyPool;
    private CellManager _cellManager;
    
    //First Init cell references
    private Cell _defaultOpenCell;
    [SerializeField] private DrawCubeGizmos _defaultCellGizmos;
    
    [Inject]
    private void Construct(EnemyPool enemyPool, CellManager cellManager)
    {
        _enemyPool = enemyPool;
        _cellManager = cellManager;
    }
    
    private void Start()
    {
        SetFirstActiveCell();
        Spawner().Forget();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActiveCellWays();
        }
    }

    private void SetFirstActiveCell()
    {
        _defaultOpenCell = _cellManager.GetDefaultCellAtActiveColumn();
        _defaultCellGizmos = new DrawCubeGizmos(_cellManager.GetCellMidPointPositionXZ(_defaultOpenCell.GridIndexX, _defaultOpenCell.GridIndexZ));
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
        if(_defaultCellGizmos.CanDrawGizmos) _defaultCellGizmos.DrawGizmos(Color.yellow); // default open cell gizmos
        if(_calculatedSpawnPoints.Count == 0) return;
        
        Gizmos.color = Color.green;
        
        for (int i = 0; i < _calculatedSpawnPoints.Count; i++)
        {
            Gizmos.DrawCube(_calculatedSpawnPoints[i],new Vector3(1f,1f,1f));
        }
    }

    private async UniTaskVoid Spawner()
    {
        foreach (var stages in _totalWaveData)
        {
            foreach (var waves in stages.WaveStages)
            {
                foreach (var wave in waves.Waves)
                {
                    for (int i = 0; i < wave.Count; i++)
                    {
                        _enemyPool.GetObjectFromPool(wave.EnemyID, _spawnPoints[0].position);
                        await UniTask.WaitForSeconds(wave.Rate);
                    }
                }
            }
        }
    }

    // private async UniTaskVoid SpawnWaveAsync()
    // {
    //     var waitTime = _waveData[0].Rate;
    //     
    //     for (int i = 0; i < _waveData.Count; i++)
    //     {
    //         for (int j = 0; j < _waveData[i].Count; j++)
    //         {
    //             _enemyPool.GetObjectFromPool(_waveData[i].EnemyID, _spawnPoints[i].position);
    //             await UniTask.WaitForSeconds(waitTime);
    //         }
    //         await UniTask.WaitForSeconds(_waveData[i].Rate);
    //     }
    // }
}