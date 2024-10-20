using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowerManager : MonoBehaviour
{
    private List<ITower> _totalTowers;
    private List<ITower> _activeTowers;
    private List<ITower> _destroyedTowers;

    private List<ITowerAttack> _attackerTowers;
    
    private TowerEvents _towerEvents;
    
    
    [Inject]
    private void Construct(TowerEvents towerEvents)
    {
        _towerEvents = towerEvents;
    }


    private void SetTotalTowers()
    {
        
        
    }


    #region GetList

    public List<ITowerAttack> GetAttackerTowers()
    {
        return _attackerTowers;
    }

    #endregion
    
}
