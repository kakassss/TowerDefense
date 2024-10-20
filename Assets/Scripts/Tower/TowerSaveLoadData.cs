using System.Collections.Generic;
using UnityEngine;

public class TowerSaveLoadData : MonoBehaviour
{
    [SerializeField] private List<BaseTower> _allTowers;

    private JsonDataService _jsonDataService;

    private void SaveAllTowerDatas()
    {
        foreach (var tower in _allTowers)
        {
            _jsonDataService.SaveData("TowersAttackData", tower.Attack,false);
        }
    }
    
}