using System;

public class InputActions
{
    private Action OnSpawnInput;
    private Action<GridEntitySO> OnGhostSpawnInput;

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
    
    public void GhostSpawnInputAction(GridEntitySO gridEntitySo)
    {
        OnGhostSpawnInput?.Invoke(gridEntitySo);
    }

    public void GhostSpawnInputAddAction(Action<GridEntitySO> action)
    {
        OnGhostSpawnInput += action;
    }

    public void GhostSpawnInputRemoveAction(Action<GridEntitySO> action)
    {
        OnGhostSpawnInput -= action;
    }
}
