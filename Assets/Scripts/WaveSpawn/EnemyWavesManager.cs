using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

public class EnemyWavesManager : MonoBehaviour
{
    [InfoBox("Enemy ID")]
    [InfoBox("Troll -> 0")]
    [InfoBox("Goblin -> 1")]
    
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<WaveDataContainer> _totalWaveData;
    [SerializeField] private Vector3 _spawnPointOffset;
    
    
    private EnemyPool _enemyPool;
    private CellManager _cellManager;
    private EnemyWavesPathFinding _enemyWavesPathFinding;
    
    //First Init cell references
    private Cell _defaultOpenCell;
    [SerializeField] private DrawCubeGizmos _defaultCellGizmos;
    
    [Inject]
    private void Construct(EnemyPool enemyPool, CellManager cellManager,EnemyWavesPathFinding enemyWavesPathFinding)
    {
        _enemyPool = enemyPool;
        _cellManager = cellManager;
        _enemyWavesPathFinding = enemyWavesPathFinding;
    }
    
    private void Start()
    {
        SetFirstActiveCell();
        //Spawner().Forget();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ActiveCellWays();
            var path = _enemyWavesPathFinding.GetCalculatedPowerSizeSpawnPoints(_spawnPointOffset);
            Debug.Log("ChoosenPath " + path);
        }
    }

    private void SetFirstActiveCell()
    {
        _defaultOpenCell = _cellManager.GetDefaultCellAtActiveColumn();
        _defaultCellGizmos = new DrawCubeGizmos(_cellManager.GetCellMidPointPositionXZ(_defaultOpenCell.GridIndexX, _defaultOpenCell.GridIndexZ));
    }
    
    
    private void OnDrawGizmos()
    {
        if(_defaultCellGizmos.CanDrawGizmos) _defaultCellGizmos.DrawGizmos(Color.yellow); // default open cell gizmos
        if(_enemyWavesPathFinding == null) return;
        if(_enemyWavesPathFinding.CalculatedSpawnPoint == Vector3.zero) return;
        
        Gizmos.color = Color.green;
        Gizmos.DrawCube(_enemyWavesPathFinding.CalculatedSpawnPoint,Vector3.one);
        
        // for (int i = 0; i < _enemyWavesPathFinding?.SpawnPoints.Count; i++)
        // {
        //     Gizmos.DrawCube(_enemyWavesPathFinding.SpawnPoints[i],new Vector3(1f,1f,1f));
        // }
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
                        var path = _enemyWavesPathFinding.GetCalculatedPowerSizeSpawnPoints(_spawnPointOffset);
                        Debug.Log("ChoosenPath " + path);
                        _enemyPool.GetObjectFromPool(wave.EnemyID,path);
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