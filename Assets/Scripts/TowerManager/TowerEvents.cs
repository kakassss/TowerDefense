using System;

public class TowerEvents
{
    private Action OnTowerSpawned;
    private Action OnTowerDestroyed;


    #region Spawn

    public void TowerSpawnedTriggerAction()
    {
        OnTowerSpawned?.Invoke();
    }

    public void TowerSpawnedAddAction(Action action)
    {
        OnTowerSpawned += action;
    }

    public void TowerSpawnedRemoveAction(Action action)
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
