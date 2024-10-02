using System.Collections.Generic;
using UnityEngine;

public class TowerSaveLoadData : MonoBehaviour
{
    [SerializeField] private List<Tower> _allTowers;

    private JsonDataService _jsonDataService;

    private void SaveAllTowerDatas()
    {
        foreach (var tower in _allTowers)
        {
            _jsonDataService.SaveData("TowersAttackData", tower.Attack,false);
        }
    }
    
}