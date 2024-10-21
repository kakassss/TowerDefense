using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowerManager
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
        
        _towerEvents.TowerSpawnedAddAction(SetTotalTowers); 
    }


    private void SetTotalTowers(ITower tower)
    {
        _totalTowers.Add(tower);
        _activeTowers.Add(tower);
    }
    
}
