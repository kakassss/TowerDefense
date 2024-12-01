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
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<WaveData> _waveData;
    
    private EnemyPool _enemyPool;

    [Inject]
    private void Construct(EnemyPool enemyPool)
    {
        _enemyPool = enemyPool;
    }

    private void Start()
    {
        SpawnWaveAsync().Forget();
        //StartCoroutine(SpawnWave());
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
    
    private IEnumerator SpawnWave()
    {
        WaitForSeconds waitfor = new WaitForSeconds(_waveData[0].Rate);
        
        for (int i = 0; i < _waveData.Count; i++)
        {
            for (int j = 0; j < _waveData[i].count; j++)
            {
                _enemyPool.GetObjectFromPool(_waveData[i].EnemyID, _spawnPoints[i].position);
                yield return waitfor;
            }
            waitfor = new WaitForSeconds(_waveData[i].Rate);
        }
    }
}
