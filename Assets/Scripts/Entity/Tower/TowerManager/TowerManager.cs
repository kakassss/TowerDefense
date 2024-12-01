using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowerManager : IDisposable
{
    private List<ITower> _totalTowers;
    private List<ITower> _activeTowers;
    private List<ITower> _destroyedTowers;

    private List<ITowerAttack> _attackerTowers;
    
    private TowerEvents _towerEvents;


    public List<ITower> TotalTowers => _totalTowers;
    public List<ITower> ActiveTowers => _activeTowers;
    public List<ITower> DestroyedTowers => _destroyedTowers;
    public List<ITowerAttack> AttackerTowers => _attackerTowers;
    
    
    [Inject]
    private void Construct(TowerEvents towerEvents)
    {
        _towerEvents = towerEvents;

        _totalTowers = new List<ITower>();
        _activeTowers = new List<ITower>();
        _destroyedTowers = new List<ITower>();

        _attackerTowers = new List<ITowerAttack>();
        
        _towerEvents.TowerSpawnedAddAction(AddTower); 
        _towerEvents.TowerDestroyedAddAction(RemoveTower);
    }
    
    private void AddTower(ITower tower)
    {
        _totalTowers.Add(tower);
        _activeTowers.Add(tower);
        
        
        Debug.Log(_totalTowers.Count);
        Debug.Log(_activeTowers.Count);
    }

    private void RemoveTower(ITower tower)
    {
        _activeTowers.Remove(tower);
        _destroyedTowers.Add(tower);
    }

    public void Dispose()
    {
        _towerEvents.TowerSpawnedRemoveAction(AddTower);
        _towerEvents.TowerDestroyedRemoveAction(RemoveTower);
    }
}
