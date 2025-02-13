using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "WaveData", order = 1)]
public class WaveDataContainer : ScriptableObject
{
    public List<WaveData> WaveStages;
}

[Serializable]
public class WaveData
{
    public List<Wave> Waves;
}

[Serializable]
public class Wave
{
    public int EnemyID;
    public int Count;
    [Range(0.5f,3f)] public float Rate;
}