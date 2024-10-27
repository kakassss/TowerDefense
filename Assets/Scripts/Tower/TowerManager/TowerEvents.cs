using System;
using System.Collections.Generic;

public class TowerEvents
{
    private Action<ITower> OnTowerSpawned;
    private Action OnTowerDestroyed;


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

    public void TowerDestroyedTriggerAction()
    {
        OnTowerDestroyed?.Invoke();
    }

    public void TowerDestroyedAddAction(Action action)
    {
        OnTowerDestroyed += action;
    }

    public void TowerDestroyedRemoveAction(Action action)
    {
        OnTowerDestroyed -= action;
    }

    #endregion
    
    
}
