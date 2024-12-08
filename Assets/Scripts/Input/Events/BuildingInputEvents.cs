using System;

public class BuildingInputEvents
{
    private Action OnSpawnInput;
    private Action<BaseObject> OnGhostSpawnInput;

    public void SpawnInputAction()
    {
        OnSpawnInput?.Invoke();
    }

    public void SpawnInputAddAction(Action action)
    {
        OnSpawnInput += action;
    }

    public void SpawnInputRemoveAction(Action action)
    {
        OnSpawnInput -= action;
    }
    
    public void GhostSpawnInputAction(BaseObject gridEntitySo)
    {
        OnGhostSpawnInput?.Invoke(gridEntitySo);
    }

    public void GhostSpawnInputAddAction(Action<BaseObject> action)
    {
        OnGhostSpawnInput += action;
    }

    public void GhostSpawnInputRemoveAction(Action<BaseObject> action)
    {
        OnGhostSpawnInput -= action;
    }
}
