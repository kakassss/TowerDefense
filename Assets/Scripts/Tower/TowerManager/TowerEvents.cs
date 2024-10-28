using System;
using System.Collections.Generic;

public class TowerEvents
{
    private Action<ITower> OnTowerSpawned;
    private Action<ITower> OnTowerDestroyed;


    #region Spawn

    public void TowerSpawnedTriggerAction(ITower towers)
    {
        OnTowerSpawned?.Invoke(towers);
    }

    public void TowerSpawnedAddAction(Action<ITower> action)
    {
        OnTowerSpawned += action;
    }

    public void TowerSpawnedRemoveAction(Action<ITower> action)
    {
        OnTowerSpawned -= action;
    }

    #endregion

    #region Destroy

    public void TowerDestroyedTriggerAction(ITower towers)
    {
        OnTowerDestroyed?.Invoke(towers);
    }

    public void TowerDestroyedAddAction(Action<ITower> action)
    {
        OnTowerDestroyed += action;
    }

    public void TowerDestroyedRemoveAction(Action<ITower> action)
    {
        OnTowerDestroyed -= action;
    }

    #endregion
    
    
}
